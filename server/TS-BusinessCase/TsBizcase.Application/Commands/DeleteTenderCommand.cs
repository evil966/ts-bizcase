using MediatR;
using TsBizcase.Application.Responses;

namespace TsBizcase.Application.Commands
{
    public record DeleteTenderCommand(int Id) : IRequest<DeleteRecordResponse>;
}
