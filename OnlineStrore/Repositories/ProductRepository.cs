using Microsoft.EntityFrameworkCore;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Commands.Product.Create;
using OnlineStrore.Commands.Product.Update;
using OnlineStrore.Exceptions;
using OnlineStrore.Repositories.Interfaces;

namespace OnlineStrore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task<Guid> CreateProductAsync(IContext context, CreateProductCommand request, CancellationToken cancellationToken)
        {
            Guid id = Guid.NewGuid();
            await context.Products.AddAsync(new Product
            {
                Id = id,
                Name = request.Name,
                Cost = request.Cost,
                CountOfProduct = request.CountOfProduct,
                ProductTypeId = (Guid)request.ProductTypeId,
            });
            await context.SaveChangesAsync(cancellationToken);
            return id;
        }

        public async Task DeleteProductAsync(IContext context, Guid id, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null || product.Id != id)
                throw new NotFoundException();
            context.Products.Remove(product);

            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(IContext context, Guid id)
        {
            var products = await context.Products.ToListAsync();
            if (products.Count == 0)
                throw new NotFoundException();
            return products;
        }

        public async Task<Product> GetProductAsync(IContext context, Guid id)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if(product == null || product.Id != id)
                throw new NotFoundException();
            return product;
        }

        public async Task<Guid> UpdateProductAsync(IContext context, UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (product == null || product.Id != request.Id)
                throw new NotFoundException();
            
            product.Name = request.Name ?? product.Name;
            product.Cost = request.Cost ?? product.Cost;
            product.CountOfProduct = request.CountOfProduct ?? product.CountOfProduct;

            await context.SaveChangesAsync(cancellationToken);
            return product.Id; 
        }
    }
}
