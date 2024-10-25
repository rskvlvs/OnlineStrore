using MediatR;
namespace OnlineStrore.Logic.Queries.ProductType.GetProductType
{
    public class GetProductTypeQuery : IRequest<ProductTypeVm>
    {
        public Guid Id { get; set; }
    }
}
