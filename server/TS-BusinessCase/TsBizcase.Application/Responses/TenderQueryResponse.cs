using System.Collections.Generic;
using TsBizcase.Application.Model;

namespace TsBizcase.Application.Responses
{
    public record TenderQueryResponse
    {
        public TenderQueryResponse(IEnumerable<TenderRecord> record)
        {
            Record = record;
        }

        public virtual IEnumerable<TenderRecord> Record { get; set; }
    };
}
