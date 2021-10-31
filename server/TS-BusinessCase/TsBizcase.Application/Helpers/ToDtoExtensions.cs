using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBizcase.Application.Model;
using TsBizcase.Application.Responses;
using TsBizcase.Core.Entities;

namespace TsBizcase.Application.Helpers
{
    public static class ToDtoExtensions
    {
        public static TenderRecord ToTenderQueryResponse(this Tender tender)
        {
            return new TenderRecord
            {
                Id = tender.Id,
                Name = tender.Name,
                ReferenceNumber = tender.ReferenceNumber,
                ReleaseDate = tender.ReleaseDate,
                ClosingDate = tender.ClosingDate,
                Description = tender.Description,
                CreatorId = tender.CreatorId
            };
        }

        public static TenderRecordResponse ToTenderRecordResponse(this Tender tender)
        {
            return new TenderRecordResponse
            {
                Id = tender.Id,
                Name = tender.Name,
                ReferenceNumber = tender.ReferenceNumber,
                ReleaseDate = tender.ReleaseDate,
                ClosingDate = tender.ClosingDate,
                Description = tender.Description,
                CreatorId = tender.CreatorId
            };
        }
    }
}
