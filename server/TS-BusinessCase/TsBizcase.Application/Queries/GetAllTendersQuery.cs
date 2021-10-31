using MediatR;
using System.Collections.Generic;
using TsBizcase.Application.Responses;

namespace TsBizcase.Application.Queries
{
    public record GetAllTendersQuery() : IRequest<TenderQueryResponse>;

}
