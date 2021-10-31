using System.Threading.Tasks;
using TsBizcase.Core.Entities;
using TsBizcase.Core.Repositories.Base;

namespace TsBizcase.Core.Repositories
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        Task<AppUser> GetUserByUserIdAsync(int id);
        Task<AppUser> GetUserByEmailAndHashedPasswordAsync(string email, string password);
    }
}
