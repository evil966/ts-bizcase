
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using TsBizcase.Core.Entities;
using TsBizcase.Core.Repositories;
using TsBizcase.Infrastructure.Data;
using TsBizcase.Infrastructure.Repositories.Base;

namespace TsBizcase.Infrastructure.Repositories
{
    public class TenderRepository : Repository<Tender>, ITenderRepository
    {
        public TenderRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Tender> GetTenderByIdAsync(int id)
        {
            var tender = _context.Tenders
                            .FromSqlInterpolated($"EXEC sp_GetTenderById @TID={id}")
                            .AsEnumerable()
                            .FirstOrDefault();

            return await Task.Run(() => tender);
        }

        public async IAsyncEnumerable<Tender> GetAllTendersAsync()
        {
            var tenders = _context.Tenders
                            .FromSqlInterpolated($"EXEC sp_GetAllTenders")
                            .AsAsyncEnumerable();

            await foreach (var order in tenders)
            {
                yield return order;
            }
        }

        public async Task<Tender> CreateTenderAsync(Tender tender)
        {
            var inserted = _context.Tenders
                            .FromSqlInterpolated($"EXEC sp_CreateTender @NAME={tender.Name}, @REFERENCENUMBER={tender.ReferenceNumber}, @RELEASEDATE={tender.ReleaseDate}, @CLOSINGDATE={tender.ClosingDate}, @DESCRIPTION={tender.Description}, @CREATORID={tender.CreatorId};")
                            .AsEnumerable()
                            .FirstOrDefault();

            return await Task.Run(() => inserted);
        }

        public async Task<Tender> UpdateTenderAsync(Tender tender)
        {
            _ = _context.Tenders
                            .FromSqlInterpolated($"EXEC sp_UpdateTender @ID={tender.Id}, @NAME={tender.Name}, @REFERENCENUMBER={tender.ReferenceNumber}, @RELEASEDATE={tender.ReleaseDate}, @CLOSINGDATE={tender.ClosingDate}, @DESCRIPTION={tender.Description}, @CREATORID={tender.CreatorId};")
                            .AsEnumerable()
                            .FirstOrDefault();

            return await Task.Run(() => tender);
        }

        public void RemoveTenderAsync(int id)
        {
            _context.Tenders
                    .FromSqlInterpolated($"EXEC sp_DeleteTender @ID={id};");

        }
    }
}
