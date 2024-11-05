using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStrore.Dto;
using OnlineStrore.Logic.Commands.Sale.Create;
using OnlineStrore.Logic.Commands.Sale.Delete;
using OnlineStrore.Logic.Queries.Sale.GetSaleList;
using OnlineStrore.Logic.Queries.Sale.GetUserSale;

namespace OnlineStrore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly IMediator mediator;

        public SaleController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Guid>> CreateSale(Guid id, CreateSaleDto saleDto, CancellationToken cancellationToken)
        {
            var request = new CreateSaleCommand() { ClientId = id, TotalSum = saleDto.TotalSum };
            var saleId = await mediator.Send(request, cancellationToken); 
            return Ok(saleId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaleListVm>> GetAllUserSales(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetSaleListQuery() { UserId = id };
            var sales = await mediator.Send(query, cancellationToken);
            return Ok(sales);
        }

        [HttpGet("{id}/last")]
        public async Task<ActionResult<SaleVm>> GetLastUserSale(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetSaleQuery() { UserId = id };
            var sales = await mediator.Send(query, cancellationToken);
            return Ok(sales);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteSaleCommand() { Id  = id };
            await mediator.Send(request, cancellationToken);
            return Ok("Sale has been deleted!"); 
        }
    }
}
