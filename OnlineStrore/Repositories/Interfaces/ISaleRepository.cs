using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Commands.Sale.Create;


namespace OnlineStrore.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetAllSalesAsync(IContext context);

        Task<Sale> GetSaleAsync(IContext context, Guid id);

        Task<Guid> CreateSaleAsync(IContext context, CreateSaleCommand request, CancellationToken cancellationToken);

        //Task<Guid> UpdateSaleAsync(IContext context, UpdateSaleCommand request, CancellationToken cancellationToken);

        Task DeleteSaleAsync(IContext context, Guid id, CancellationToken cancellationToken);
    }
}
