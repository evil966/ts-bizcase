namespace TsBizcase.Application.Responses
{
    public class DeleteRecordResponse
    {
        public string Message { get; set; }
        public TenderRecordResponse DeletedRecord { get; set; }
    }

}
