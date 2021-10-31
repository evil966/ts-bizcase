using MediatR;
using TsBizcase.Application.Responses;

namespace TsBizcase.Application.Queries
{
    public record GetAppUserByIdQuery(int Id) : IRequest<AppUserQueryResponse>;
}
