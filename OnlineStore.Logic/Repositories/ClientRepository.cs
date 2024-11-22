using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using OnlineStore.Logic.Auth.Hasher;
using OnlineStore.Logic.Commands.Client.Login;
using OnlineStore.Logic.JWT;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Commands.Client.Create;
using OnlineStrore.Logic.Commands.Client.Update;
using OnlineStrore.Logic.Exceptions;
using OnlineStrore.Logic.Queries.Client.GetClient;
using OnlineStrore.Logic.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IPasswordHasher passwordHasher;
        private readonly IJwtPorvider jwtProvider; 

        public ClientRepository(IPasswordHasher _passwordHasher, IJwtPorvider _jwtprovider)
            => (passwordHasher, jwtProvider) = (_passwordHasher, _jwtprovider);
        public async Task<string> CreateClientAsync(IContext context, CreateClientCommand request, CancellationToken cancellationToken)
        {
            if (await context.Clients.FirstOrDefaultAsync(c => c.Email == request.Email, cancellationToken) != null)
                throw new ValidationException("Client with this Email has already been created");
            Guid id = Guid.NewGuid();
            var hashedpassword = passwordHasher.Generate(request.Password);
            var client = new Client()
            {
                Id = id,
                Name = request.Name,
                Email = request.Email,
                Password = hashedpassword,
                PhoneNumber = request.PhoneNubmer
            };
            await context.Clients.AddAsync(client, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            var token = jwtProvider.GenerateToken(client);
            
            return token;
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

        public async Task<Client> GetClientByEmailAsync(IContext context, string email, CancellationToken cancellationToken)
        {
            var client = await context.Clients.FirstOrDefaultAsync(c => c.Email == email, cancellationToken);

            if (client == null || client.Email != email)
                throw new NotFoundException();
            return client;
        }

        public async Task<string> LoginClientAsync(IContext context, LoginClientCommand request, CancellationToken cancellationtoken)
        {
            try
            {
                var client = await GetClientByEmailAsync(context, request.Email, cancellationtoken);
                var result = passwordHasher.Verify(request.Password, client.Password);
                if (result == false)
                    throw new ValidationException("Wrong passwod or Email");

                var token = jwtProvider.GenerateToken(client); 
                return token;                     
            }
            catch
            {
                throw new ValidationException("Wrong passwod or Email");
            }
            
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
