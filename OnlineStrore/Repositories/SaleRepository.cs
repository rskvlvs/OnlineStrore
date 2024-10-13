using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Commands.Sale.Create;
using OnlineStrore.Exceptions;
using OnlineStrore.Repositories.Interfaces;
using System.Security.Cryptography.Xml;

namespace OnlineStrore.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        public async Task<Guid> CreateSaleAsync(IContext context, CreateSaleCommand request, CancellationToken cancellationToken)
        {
            Guid id = Guid.NewGuid();
            var sale = new Sale()
            {
                Id = id,
                DateTime = DateTime.Now,
                ClientId = request.ClientId,
                TotalSum = request.TotalSum,
            };
            await context.Sales.AddAsync(sale);
            await context.SaveChangesAsync(cancellationToken);
            return id;
        }

        public async Task DeleteSaleAsync(IContext context, Guid id, CancellationToken cancellationToken)
        {
            var sale = await context.Sales.FirstOrDefaultAsync(s => s.Id == id);
            if (sale == null || sale.Id != id)
                throw new NotFoundException(id);
            context.Sales.Remove(sale);
            await context.SaveChangesAsync(cancellationToken); 
        }

        public async Task<IEnumerable<Sale>> GetAllSalesAsync(IContext context)
        {
            var sales = await context.Sales.ToListAsync();
            if (sales.Count == 0)
                throw new NotFoundException();
            return sales;
        }

        public async Task<Sale> GetSaleAsync(IContext context, Guid id)
        {
            var sale = await context.Sales.FirstOrDefaultAsync(s => s.Id == id);
            if(sale == null || sale.Id != id)
                throw new NotFoundException(id);
            return sale;
        }

    }
}
