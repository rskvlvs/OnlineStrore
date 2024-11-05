using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStrore.Dto;
using OnlineStrore.Logic.Commands.Client.Create;
using OnlineStrore.Logic.Commands.Client.Delete;
using OnlineStrore.Logic.Commands.Client.Update;
using OnlineStrore.Logic.Commands.Manager.Create;
using OnlineStrore.Logic.Commands.Manager.Delete;
using OnlineStrore.Logic.Commands.Manager.Update;
using OnlineStrore.Logic.Queries.Client.GetClient;
using OnlineStrore.Logic.Queries.Client.GetClientList;
using OnlineStrore.Logic.Queries.Manager.GetManager;
using OnlineStrore.Logic.Queries.Manager.GetManagerList;

namespace OnlineStrore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IMediator mediator;

        public ManagerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateManager(CreateManagerCommand request, CancellationToken cancellationToken)
        {
            var id = await mediator.Send(request, cancellationToken);
            return Ok(id);
        }

        [HttpGet]
        public async Task<ActionResult<ManagerListVm>> GetAllManagers(CancellationToken cancellationToken)
        {
            var managers = await mediator.Send(new GetManagerListQuery(), cancellationToken);
            return Ok(managers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ManagerVm>> GetManager(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetManagerQuery() { Id = id };
            var manager = await mediator.Send(query, cancellationToken);
            return Ok(manager);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Guid>> UpdateManager(Guid id, UpdateManagerDto managerDto, CancellationToken cancellationToken)
        {
            var request = new UpdateManagerCommand()
            {
                Id = id,
                Name = managerDto.Name,
                Email = managerDto.Email,
                PhoneNumber = managerDto.PhoneNumber,
            };
            var managerId = await mediator.Send(request, cancellationToken);
            return Ok(managerId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteManagerCommand() { Id = id };
            await mediator.Send(request, cancellationToken);
            return Ok("Manager has been deleted!");
        }

        
    }
}
