using MediatR;
using TsBizcase.Application.Responses;

namespace TsBizcase.Application.Queries
{
    public record GetAppUserByPasswordQuery(string Email, string Password) : IRequest<AppUserQueryResponse>;
}
