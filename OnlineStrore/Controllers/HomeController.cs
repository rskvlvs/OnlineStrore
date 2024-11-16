
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using OnlineStrore.Logic.Queries.Client.GetClient;


namespace OnlineStrore.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {

            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Index(bool isAuthorize = false)
        {
            ViewBag.IsUserLoggedIn = isAuthorize;
            return View();
        }

        [HttpGet("Sale")]
        public async Task<ActionResult> Sale(bool isAuthorize = false)
        {
            ViewBag.IsUserLoggedIn = isAuthorize;
            return View();
        }

        [HttpGet("News")]
        public async Task<ActionResult> News(bool isAuthorize = false)
        {
            ViewBag.IsUserLoggedIn = isAuthorize;
            return View();
        }

        [HttpGet("Contact")]
        public async Task<ActionResult> Contact(bool isAuthorize = false)
        {
            ViewBag.IsUserLoggedIn = isAuthorize;

            return View();
        }

        public bool IsUserLoggedIn()
        {
            return HttpContext.Request.Cookies.ContainsKey("tasty-cookies");
        }
    }
}
