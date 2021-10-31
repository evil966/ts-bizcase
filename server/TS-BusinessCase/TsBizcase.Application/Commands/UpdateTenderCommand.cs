using MediatR;
using TsBizcase.Application.Model;
using TsBizcase.Application.Responses;

namespace TsBizcase.Application.Commands
{
    public record UpdateTenderCommand(TenderRecord Input) : IRequest<TenderRecordResponse>;
}
