using Microsoft.EntityFrameworkCore;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Commands.Client.Create;
using OnlineStrore.Commands.Client.Update;
using OnlineStrore.Exceptions;
using OnlineStrore.Repositories.Interfaces;

namespace OnlineStrore.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public async Task<Guid> CreateClientAsync(IContext context, CreateClientCommand request, CancellationToken cancellationToken)
        {
            Guid id = Guid.NewGuid();
            await context.Clients.AddAsync(new Client
            {
                Id = id,
                Name = request.Name,
                Email = request.Email
            });
            await context.SaveChangesAsync(cancellationToken);
            return id;
        }

        public async Task DeleteClientAsync(IContext context, Guid id, CancellationToken cancellationToken)
        {
            var client = await context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client == null || client.Id != id)
                throw new NotFoundException(id);

            context.Clients.Remove(client);
            await context.SaveChangesAsync(cancellationToken); 
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync(IContext context)
        {
            var clients = await context.Clients.ToListAsync();
            if (clients.Count == 0)
                throw new NotFoundException(); 
            return (clients);
        }

        public async Task<Client> GetClientAsync(IContext context, Guid id)
        {
            var client = await context.Clients.FirstOrDefaultAsync(c => c.Id == id);

            if (client == null || client.Id != id)
                throw new NotFoundException(id);
            return client;
        }

        public async Task<Guid> UpdateClientAsync(IContext context, UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = context.Clients.FirstOrDefault(c => c.Id == request.Id);
            if (client == null || client.Id != request.Id)
                throw new NotFoundException(request.Id);
            
            client.Name = request.Name ?? client.Name;
            client.Email = request.Email ?? client.Email;
            await context.SaveChangesAsync(cancellationToken);

            return client.Id;
        }
    }
}
