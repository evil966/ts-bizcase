using System.Collections.Generic;
using System.Threading.Tasks;
using TsBizcase.Core.Entities;
using TsBizcase.Core.Repositories.Base;

namespace TsBizcase.Core.Repositories
{
    public interface ITenderRepository : IRepository<Tender>
    {
        Task<Tender> GetTenderByIdAsync(int id);
        IAsyncEnumerable<Tender> GetAllTendersAsync();
        Task<Tender> CreateTenderAsync(Tender tender);
        Task<Tender> UpdateTenderAsync(Tender tender);
        void RemoveTenderAsync(int id);
    }
}
