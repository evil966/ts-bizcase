﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TsBizcase.Application.Commands;
using TsBizcase.Application.Helpers;
using TsBizcase.Application.Responses;
using TsBizcase.Core.Entities;
using TsBizcase.Core.Repositories;

namespace TsBizcase.Application.Handlers
{
    public class CreateTenderHandler : IRequestHandler<CreateTenderCommand, TenderRecordResponse>
    {
        private readonly ITenderRepository _repo;
        public CreateTenderHandler(ITenderRepository repo)
        {
            _repo = repo;
        }

        public async Task<TenderRecordResponse> Handle(CreateTenderCommand request, CancellationToken cancellationToken)
        {
            var tender = await _repo.CreateTenderAsync(new Tender()
            {
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
