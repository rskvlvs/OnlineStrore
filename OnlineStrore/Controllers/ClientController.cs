using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("allClientsInfo")]
        public async Task<ActionResult<ClientListVm>> GetAllClients(CancellationToken cancellationToken)
        {
            var clients = await mediator.Send(new GetClientListQuery(), cancellationToken);
            return Ok(clients);
        }

        [Authorize]
        [HttpGet("clientInfo")]
        public async Task<ActionResult<ClientVm>> GetClient(CancellationToken cancellationToken)
        {
            bool res = Guid.TryParse(HttpContext.User.FindFirst("clientId")?.Value, out Guid id);
            if (!res)
                return BadRequest(); 
            var query = new GetClientQuery() { Id = id };
            var client = await mediator.Send(query, cancellationToken);
            return Ok(client);
        }

        [Authorize]
        [HttpPatch("updateClient")]
        public async Task<ActionResult<Guid>> UpdateClient(UpdateClientDto clientDto, CancellationToken cancellationToken)
        {
            bool res = Guid.TryParse(HttpContext.User.FindFirst("clientId")?.Value, out Guid id);
            if (!res)
                return BadRequest();
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

        [Authorize]
        [HttpDelete("deleteClient")]
        public async Task<IActionResult> DeleteClient(CancellationToken cancellationToken)
        {
            bool res = Guid.TryParse(HttpContext.User.FindFirst("clientId")?.Value, out Guid id);
            if (!res)
                return BadRequest();
            var request = new DeleteClientCommand() { Id = id };
            await mediator.Send(request, cancellationToken);
            return Ok("Client has been deleted!");
        }       
    }
}
