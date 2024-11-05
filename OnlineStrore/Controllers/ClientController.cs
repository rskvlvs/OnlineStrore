using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Logic.Commands.Client.Login;
using OnlineStrore.Dto;
using OnlineStrore.Logic.Commands.Client.Create;
using OnlineStrore.Logic.Commands.Client.Delete;
using OnlineStrore.Logic.Commands.Client.Update;
using OnlineStrore.Logic.Queries.Client.GetClient;
using OnlineStrore.Logic.Queries.Client.GetClientList;

namespace OnlineStrore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator mediator;

        public ClientController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateClient(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var id = await mediator.Send(request, cancellationToken);
            return Ok(id);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginClient(LoginClientCommand request, CancellationToken cancellationToken)
        {
            var token = await mediator.Send(request, cancellationToken);
            HttpContext.Response.Cookies.Append("tasty-cookies", token);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<ClientListVm>> GetAllClients(CancellationToken cancellationToken)
        {
            var clients = await mediator.Send(new GetClientListQuery(), cancellationToken);
            return Ok(clients);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClientVm>> GetClient(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetClientQuery() { Id = id };
            var client = await mediator.Send(query, cancellationToken);
            return Ok(client);
        }

        [HttpPatch("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateClient(Guid id, UpdateClientDto clientDto, CancellationToken cancellationToken)
        {
            var request = new UpdateClientCommand()
            {
                Id = id,
                Name = clientDto.Name,
                Email = clientDto.Email,
                PhoneNumber = clientDto.PhoneNumber,
            };
            var clientId = await mediator.Send(request, cancellationToken);
            return Ok(clientId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteClient(Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteClientCommand() { Id = id };
            await mediator.Send(request, cancellationToken);
            return Ok("Client has been deleted!");
        }       
    }
}
