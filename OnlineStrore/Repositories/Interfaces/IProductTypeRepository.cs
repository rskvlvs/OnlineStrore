
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Commands.ProductType.Create;
using OnlineStrore.Commands.ProductType.Update;

namespace OnlineStrore.Repositories.Interfaces
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductType>> GetAllProductTypesAsync(IContext context);

        Task<ProductType> GetProductTypeAsync(IContext context, Guid id);

        Task<Guid> CreateProductTypeAsync(IContext context, CreateProductTypeCommand request, CancellationToken cancellationToken);

        Task<Guid> UpdateProductTypeAsync(IContext context, UpdateProductTypeCommand request, CancellationToken cancellationToken);

        Task DeleteProductTypeAsync(IContext context, Guid id, CancellationToken cancellationToken);
    }
}
