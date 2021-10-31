using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TsBizcase.Api.Filters;
using TsBizcase.Api.Filters.Helpers;
using TsBizcase.Application.Factories;
using TsBizcase.Application.Model;
using TsBizcase.Application.Responses;

namespace TsBizcase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IQueryMaker _query;

        public TenderController(IMediator mediator, IQueryMaker query)
        {
            _mediator = mediator;
            _query = query;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IQueryable<TenderRecord>> GetAll()
        {
            var data = await _mediator.Send(_query.GetAllTendersQuery());
            return data.Record.AsQueryable();
        }

        [HttpPost]
        [ValidateInputOnPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<TenderRecordResponse> PostAsync()
        {
            var input = await RequestBodyReader.GetBody<TenderRecordInput>(Request);
            return await _mediator.Send(_query.CreateTenderCommand(input));
        }

        [HttpPut]
        [ValidateInputOnPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<TenderRecordResponse> PutAsync()
        {
            var input = await RequestBodyReader.GetBody<TenderRecord>(Request);
            return await _mediator.Send(_query.UpdateTenderCommand(input));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<DeleteRecordResponse> DeleteAsync(int id)
        {
            return await _mediator.Send(_query.DeleteTenderCommand(id));
        }
    }
}
