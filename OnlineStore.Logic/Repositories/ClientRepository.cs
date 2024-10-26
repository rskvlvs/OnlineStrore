using Microsoft.EntityFrameworkCore;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Commands.Client.Create;
using OnlineStrore.Logic.Commands.Client.Update;
using OnlineStrore.Logic.Exceptions;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public async Task<Guid> CreateClientAsync(IContext context, CreateClientCommand request, CancellationToken cancellationToken)
        {
            if (await context.Clients.FirstOrDefaultAsync(c => c.Email == request.Email, cancellationToken) != null)
                throw new AlreadyCreatedException(request.Email);
            Guid id = Guid.NewGuid();       
            await context.Clients.AddAsync(new Client
            {
                Id = id,
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                PhoneNumber = request.PhoneNubmer
            }, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return id;
        }

        public async Task DeleteClientAsync(IContext context, Guid id, CancellationToken cancellationToken)
        {
            var client = await context.Clients.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (client == null || client.Id != id)
                throw new NotFoundException(id);

            context.Clients.Remove(client);
            await context.SaveChangesAsync(cancellationToken); 
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync(IContext context, CancellationToken cancellationToken)
        {
            var clients = await context.Clients.ToListAsync(cancellationToken);
            if (clients.Count == 0)
                throw new NotFoundException(); 
            return (clients);
        }

        public async Task<Client> GetClientAsync(IContext context, Guid id, CancellationToken cancellationToken)
        {
            var client = await context.Clients.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (client == null || client.Id != id)
                throw new NotFoundException(id);
            return client;
        }

        public async Task<Guid> UpdateClientAsync(IContext context, UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await context.Clients.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            if (client == null || client.Id != request.Id)
                throw new NotFoundException(request.Id);
            
            client.Name = request.Name ?? client.Name;
            client.Email = request.Email ?? client.Email;
            client.PhoneNumber = request.PhoneNumber ?? client.PhoneNumber;
            await context.SaveChangesAsync(cancellationToken);

            return client.Id;
        }
    }
}
