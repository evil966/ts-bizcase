using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TsBizcase.Application.Commands;
using TsBizcase.Application.Helpers;
using TsBizcase.Application.Responses;
using TsBizcase.Core.Repositories;

namespace TsBizcase.Application.Handlers
{
    public class DeleteTenderHandler : IRequestHandler<DeleteTenderCommand, DeleteRecordResponse>
    {
        private readonly ITenderRepository _repo;
        public DeleteTenderHandler(ITenderRepository repo)
        {
            _repo = repo;
        }

        public async Task<DeleteRecordResponse> Handle(DeleteTenderCommand request, CancellationToken cancellationToken)
        {
            var tender = await _repo.GetByIdAsync(request.Id);
            if (tender == null) return default;

            _repo.RemoveTenderAsync(request.Id);

            return await Task.Run(() => 
                    new DeleteRecordResponse 
                    {   Message = "Information on the deleted record:", 
                        DeletedRecord = tender.ToTenderRecordResponse() 
                    });
        }

    }
}
