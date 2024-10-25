using MediatR;
namespace OnlineStrore.Logic.Queries.Sale.GetSaleList
{
    public class GetSaleListQuery : IRequest<SaleListVm>
    {
        public Guid UserId { get; set; }
    }
}
