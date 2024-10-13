using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Commands.ProductType.Create;
using OnlineStrore.Commands.ProductType.Update;
using OnlineStrore.Exceptions;
using OnlineStrore.Repositories.Interfaces;

namespace OnlineStrore.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        public async Task<Guid> CreateProductTypeAsync(IContext context, CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            Guid id = Guid.NewGuid();
            var type = new ProductType
            {
                Id = id,
                Name = request.Name
            };
            await context.ProductTypes.AddAsync(type);
            await context.SaveChangesAsync(cancellationToken);
            return id;
        }

        public async Task DeleteProductTypeAsync(IContext context, Guid id, CancellationToken cancellationToken)
        {
            var type = await context.ProductTypes.FirstOrDefaultAsync(t => t.Id == id);
            if (type == null || type.Id != id)
                throw new NotFoundException(id);

            context.ProductTypes.Remove(type);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ProductType>> GetAllProductTypesAsync(IContext context)
        {
            var types = await context.ProductTypes.ToListAsync();
            if (types.Count == 0)
                throw new NotFoundException();
            return types;
        }

        public async Task<ProductType> GetProductTypeAsync(IContext context, Guid id)
        {
            var type = await context.ProductTypes.FirstOrDefaultAsync(t => t.Id == id);
            if (type == null || type.Id != id)
                throw new NotFoundException(id);

            return type;
        }

        public async Task<Guid> UpdateProductTypeAsync(IContext context, UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var type = await context.ProductTypes.FirstOrDefaultAsync(t => t.Id == request.Id);
            if (type == null || type.Id != request.Id)
                throw new NotFoundException(request.Id);

            type.Name = request.Name ?? type.Name;
            await context.SaveChangesAsync(cancellationToken);
            return type.Id;
        }
    }
}
