using System;

namespace TsBizcase.Application.Model
{
    public class TenderRecordInput
    {
        public string Name { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
    }
}
