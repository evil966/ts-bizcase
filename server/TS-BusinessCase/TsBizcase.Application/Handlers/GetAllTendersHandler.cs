using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TsBizcase.Application.Helpers;
using TsBizcase.Application.Model;
using TsBizcase.Application.Queries;
using TsBizcase.Application.Responses;
using TsBizcase.Core.Repositories;

namespace TsBizcase.Application.Handlers
{
    public class GetAllTendersHandler : IRequestHandler<GetAllTendersQuery, TenderQueryResponse>
    {
        private readonly ITenderRepository _repo;
        public GetAllTendersHandler(ITenderRepository repo)
        {
            _repo = repo;
        }

        public async Task<TenderQueryResponse> Handle(GetAllTendersQuery request, CancellationToken cancellationToken)
        {
            var tenders = _repo.GetAllTendersAsync();
            if (tenders is not null)
            {
                var records = new List<TenderRecord>();
                await foreach (var tender in tenders)
                {
                    records.Add(tender.ToTenderQueryResponse());
                }

                return await Task.Run(() => new TenderQueryResponse(records));
            }

            return default;
        }
    }
}
