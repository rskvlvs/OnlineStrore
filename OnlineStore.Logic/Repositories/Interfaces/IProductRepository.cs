﻿using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Commands.Product.Create;
using OnlineStrore.Logic.Commands.Product.Update;



namespace OnlineStrore.Logic.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(IContext context, CancellationToken cancellationToken);

        Task<Product> GetProductAsync(IContext context, Guid id, CancellationToken cancellationToken);

        Task<Guid> CreateProductAsync(IContext context, CreateProductCommand request, CancellationToken cancellationToken);

        Task<Guid> UpdateProductAsync(IContext context, UpdateProductCommand request, CancellationToken cancellationToken);

        Task DeleteProductAsync(IContext context, Guid id, CancellationToken cancellationToken);
    }
}