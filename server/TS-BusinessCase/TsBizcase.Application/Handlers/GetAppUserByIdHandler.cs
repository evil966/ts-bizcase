using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TsBizcase.Application.Queries;
using TsBizcase.Application.Responses;
using TsBizcase.Core.Repositories;

namespace TsBizcase.Application.Handlers
{
    public class GetAppUserByIdHandler : IRequestHandler<GetAppUserByIdQuery, AppUserQueryResponse>
    {
        private readonly IAppUserRepository _repo;
        public GetAppUserByIdHandler(IAppUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<AppUserQueryResponse> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repo.GetUserByUserIdAsync(request.Id);
            if (user is not null)
            {
                return await Task.Run(() => new AppUserQueryResponse(user.Id, user.Name, user.Email));
            }
            return default;
        }
    }
}
