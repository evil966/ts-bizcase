using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TsBizcase.Application.Commands;
using TsBizcase.Application.Helpers;
using TsBizcase.Application.Responses;
using TsBizcase.Core.Entities;
using TsBizcase.Core.Repositories;

namespace TsBizcase.Application.Handlers
{
    public class UpdateTenderHandler : IRequestHandler<UpdateTenderCommand, TenderRecordResponse>
    {
        private readonly ITenderRepository _repo;
        public UpdateTenderHandler(ITenderRepository repo)
        {
            _repo = repo;
        }

        public async Task<TenderRecordResponse> Handle(UpdateTenderCommand request, CancellationToken cancellationToken)
        {
            var find = await _repo.GetByIdAsync(request.Input.Id);
            if (find == null) return default;

            var tender = await _repo.UpdateTenderAsync(new Tender()
            {
                Id = request.Input.Id,
                Name = request.Input.Name,
                ReferenceNumber = request.Input.ReferenceNumber,
                Description = request.Input.Description,
                CreatorId = request.Input.CreatorId,
                ReleaseDate = request.Input.ReleaseDate,
                ClosingDate = request.Input.ClosingDate
            });

            return await Task.Run(() => tender.ToTenderRecordResponse());
        }
    }
}
