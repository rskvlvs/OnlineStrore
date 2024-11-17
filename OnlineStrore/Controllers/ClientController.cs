using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Logic.Commands.Client.Login;
using OnlineStore.Logic.Commands.Feedback;
using OnlineStrore.Dto;
using OnlineStrore.Logic.Commands.Client.Create;
using OnlineStrore.Logic.Commands.Client.Delete;
using OnlineStrore.Logic.Commands.Client.Update;
using OnlineStrore.Logic.Queries.Client.GetClient;
using OnlineStrore.Logic.Queries.Client.GetClientList;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace OnlineStrore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly IMediator mediator;

        public ClientController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost("CreateClient")]
        public async Task<IActionResult> CreateClient([FromForm]CreateClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var token = await mediator.Send(request, cancellationToken);
                HttpContext.Response.Cookies.Append("tasty-cookies", token);

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Create" ,new CreateClientCommand());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Create")]
        public async Task<IActionResult> RegisterView()
        {
            return View("Register", new CreateClientCommand()); 
        }

        [HttpPost("LoginClient")]
        public async Task<ActionResult> LoginClient([FromForm]LoginClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var token = await mediator.Send(request, cancellationToken);
                HttpContext.Response.Cookies.Append("tasty-cookies", token);

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            catch(ValidationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Login", new LoginClientCommand());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Login")]
        public async Task<ActionResult<string>> loginView()
        {
            return View("Login", new LoginClientCommand());
        }


        [HttpGet("allClientsInfo")]
        public async Task<ActionResult<ClientListVm>> GetAllClients(CancellationToken cancellationToken)
        {
            var clients = await mediator.Send(new GetClientListQuery(), cancellationToken);
            return Ok(clients);
        }

        [Authorize]
        [HttpGet("getUserName")]
        public async Task<IActionResult> GetUserName()
        {
            bool res = Guid.TryParse(HttpContext.User.FindFirst("clientId")?.Value, out Guid id);
            if (!res)
                return BadRequest();
            var query = new GetClientQuery() { Id = id };
            var client = await mediator.Send(query);

            var name = client.Name;

            if (!string.IsNullOrEmpty(name))
            {
                return Ok(new { name });
            }

            return Unauthorized();
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

        [Authorize]
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            bool res = Guid.TryParse(HttpContext.User.FindFirst("clientId")?.Value, out Guid id);
            if (!res)
                return BadRequest();
            var query = new GetClientQuery() { Id = id };
            var client = await mediator.Send(query);

            HttpContext.Response.Cookies.Delete("tasty-cookies");  // Удаляем куки с токеном
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [Authorize]
        [HttpGet("Feedback")]
        public async Task<IActionResult> Feedback()
        {
            return View(); 
        }

        [HttpPost("ClientFeedback")]
        public async Task<ActionResult> CreateFeedback([FromForm]CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            await mediator.Send(request, cancellationToken);
            return RedirectToAction(nameof(HomeController.Index), "Home"); 
        }
    }
}
