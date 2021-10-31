using TsBizcase.Application.Commands;
using TsBizcase.Application.Model;
using TsBizcase.Application.Queries;

namespace TsBizcase.Application.Factories
{
    public interface IQueryMaker
    {
        GetAppUserByIdQuery GetAppUserByIdQuery(int Id);
        GetAppUserByPasswordQuery GetAppUserByPasswordQuery(string Email, string Password);
        GetAllTendersQuery GetAllTendersQuery();
        CreateTenderCommand CreateTenderCommand(TenderRecordInput Input);
        UpdateTenderCommand UpdateTenderCommand(TenderRecord Input);
        DeleteTenderCommand DeleteTenderCommand(int Id);
    }
}
