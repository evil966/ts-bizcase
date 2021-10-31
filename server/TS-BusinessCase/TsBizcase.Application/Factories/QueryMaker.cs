using TsBizcase.Application.Commands;
using TsBizcase.Application.Model;
using TsBizcase.Application.Queries;

namespace TsBizcase.Application.Factories
{
    public class QueryMaker : IQueryMaker
    {
        public GetAppUserByIdQuery GetAppUserByIdQuery(int Id) => new(Id);
        public GetAppUserByPasswordQuery GetAppUserByPasswordQuery(string Email, string Password) => new(Email, Password);
        public GetAllTendersQuery GetAllTendersQuery() => new();
        public CreateTenderCommand CreateTenderCommand(TenderRecordInput Input) => new(Input);
        public UpdateTenderCommand UpdateTenderCommand(TenderRecord Input) => new(Input);
        public DeleteTenderCommand DeleteTenderCommand(int Id) => new(Id);
    }
}
