using MediatR;
namespace OnlineStrore.Logic.Queries.Sale.GetUserSale
{
    public class GetSaleQuery : IRequest<SaleVm>
    {
        public Guid UserId { get; set; }
    }
}
