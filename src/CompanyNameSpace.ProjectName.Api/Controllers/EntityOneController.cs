using MediatR;
using Microsoft.AspNetCore.Mvc;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Commands.CreateEntityOne;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Commands.DeleteEntityOne;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Commands.UpdateEntityOne;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneDetail;
using CompanyNameSpace.ProjectName.Application.Features.EntityOne.Queries.GetEntityOneList;

namespace CompanyNameSpace.ProjectName.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityOneController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntityOneController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllEntityOnes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EntityOneListVm>>> GetAllEntityOnes()
        {
            var dtos = await _mediator.Send(new GetEntityOneListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetEntityOneById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityOneDetailVm>> GetEntityOneById(int id)
        {
            var getEntityOneDetailQuery = new GetEntityOneDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getEntityOneDetailQuery));
        }

        [HttpPost(Name = "AddEntityOne")]
        public async Task<ActionResult<int>> Create([FromBody] CreateEntityOneCommand createEntityOneCommand)
        {
            var id = await _mediator.Send(createEntityOneCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateEntityOne")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateEntityOneCommand updateEntityOneCommand)
        {
            await _mediator.Send(updateEntityOneCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEntityOne")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteEntityOneCommand = new DeleteEntityOneCommand() { EntityOneId = id };
            await _mediator.Send(deleteEntityOneCommand);
            return NoContent();
        }
    }
}
