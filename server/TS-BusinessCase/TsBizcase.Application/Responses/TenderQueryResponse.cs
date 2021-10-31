using System.Collections.Generic;
using TsBizcase.Application.Model;

namespace TsBizcase.Application.Responses
{
    public record TenderQueryResponse(IEnumerable<TenderRecord> Record);
}
