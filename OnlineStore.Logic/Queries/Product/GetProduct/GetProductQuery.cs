using MediatR;

namespace OnlineStrore.Logic.Queries.Product.GetProduct
{
    public class GetProductQuery : IRequest<ProductVm>
    {
        public Guid Id { get; set; }
    }
}
