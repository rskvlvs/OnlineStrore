using Microsoft.AspNetCore.Http.HttpResults;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Commands.Product.Create;
using OnlineStrore.Commands.Product.Update;


namespace OnlineStrore.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(IContext context, Guid id);

        Task<Product> GetProductAsync(IContext context, Guid id);

        Task<Guid> CreateProductAsync(IContext context, CreateProductCommand request, CancellationToken cancellationToken);

        Task<Guid> UpdateProductAsync(IContext context, UpdateProductCommand request, CancellationToken cancellationToken);

        Task DeleteProductAsync(IContext context, Guid id, CancellationToken cancellationToken);
    }
}
