using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStrore.Logic.Commands.Client.Create;

namespace OnlineStrore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator mediator;

        public ClientController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientCommand createClientCommand, CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = await mediator.Send(createClientCommand, cancellationToken);
            return Ok(id); 
        }

    }
}
