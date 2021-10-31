using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TsBizcase.Application.Queries;
using TsBizcase.Application.Responses;
using TsBizcase.Core.Repositories;

namespace TsBizcase.Application.Handlers
{
    public class GetAppUserByPasswordHandler : IRequestHandler<GetAppUserByPasswordQuery, AppUserQueryResponse>
    {
        private readonly IAppUserRepository _repo;
        public GetAppUserByPasswordHandler(IAppUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<AppUserQueryResponse> Handle(GetAppUserByPasswordQuery request, CancellationToken cancellationToken)
        {
            var user = await _repo.GetUserByEmailAndHashedPasswordAsync(request.Email, request.Password);
            if (user is not null)
            {
                return await Task.Run(() => new AppUserQueryResponse(user.Id, user.Name, user.Email));
            }
            return default;
        }
    }

}
