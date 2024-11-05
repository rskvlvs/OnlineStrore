using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStrore.Dto;
using OnlineStrore.Logic.Commands.Product.Create;
using OnlineStrore.Logic.Commands.Product.Delete;
using OnlineStrore.Logic.Commands.Product.Update;
using OnlineStrore.Logic.Queries.Product.GetProduct;
using OnlineStrore.Logic.Queries.Product.GetProductList;

namespace OnlineStrore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await mediator.Send(request, cancellationToken); 
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<ProductListVm>> GetAllProducts(CancellationToken cancellationToken)
        {
            var products = await mediator.Send(new GetProductListQuery(),cancellationToken);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVm>> GetProduct(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetProductQuery() { Id = id};
            var product = await mediator.Send(query, cancellationToken);
            return Ok(product);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Guid>> UpdateProduct(Guid id, UpdateProductDto productDto, CancellationToken cancellationToken)
        {
            var request = new UpdateProductCommand()
            {
                Id = id,
                Name = productDto.Name,
                Cost = productDto.Cost,
                CountOfProduct = productDto.CountOfProduct,
            };
            var productId = await mediator.Send(request, cancellationToken);
            return Ok(productId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await mediator.Send(request, cancellationToken);
            return Ok("Product has been deleted!");
        }
    }
}
