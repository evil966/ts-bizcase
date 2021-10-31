using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TsBizcase.Application.Queries;
using TsBizcase.Application.Factories;
using TsBizcase.Application.Responses;

namespace TsBizcase.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IQueryMaker _query;

        public UserController(IMediator mediator, IQueryMaker query)
        {
            _mediator = mediator;
            _query = query;
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public async Task<AppUserQueryResponse> GetById(int id)
        {
            return await _mediator.Send(_query.GetAppUserByIdQuery(id));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("q")]
        public async Task<AppUserQueryResponse> GetByPassword([FromHeader] string email, [FromHeader] string password)
        {
            return await _mediator.Send(_query.GetAppUserByPasswordQuery(email, password));
        }
    }
}
