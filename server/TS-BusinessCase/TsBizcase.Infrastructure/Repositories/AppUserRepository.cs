using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TsBizcase.Core.Entities;
using TsBizcase.Core.Repositories;
using TsBizcase.Infrastructure.Data;
using TsBizcase.Infrastructure.Repositories.Base;

namespace TsBizcase.Infrastructure.Repositories
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<AppUser> GetUserByUserIdAsync(int id)
        {
            var user = _context.AppUsers
                            .FromSqlInterpolated($"EXEC sp_GetAppUserById @UID={id}")
                            .AsEnumerable()
                            .FirstOrDefault();

            return await Task.Run(() => user);
        }

        public async Task<AppUser> GetUserByEmailAndHashedPasswordAsync(string email, string password)
        {
            var user = _context.AppUsers
                            .FromSqlInterpolated($"EXEC sp_GetAppUserByEmailAndPassword @EMAIL={email}, @PASSWORD={password}")
                            .AsEnumerable()
                            .FirstOrDefault();
                     
            return await Task.Run(() => user);
        }
    }
}
