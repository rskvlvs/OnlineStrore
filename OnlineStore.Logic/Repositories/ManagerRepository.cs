using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Logic.Auth.Hasher;
using OnlineStore.Logic.Commands.Manager.Login;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Commands.Manager.Create;
using OnlineStrore.Logic.Commands.Manager.Update;
using OnlineStrore.Logic.Exceptions;
using OnlineStrore.Logic.Repositories.Interfaces;
using System.Threading;

namespace OnlineStrore.Logic.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly IPasswordHasher passwordHasher;

        public ManagerRepository(IPasswordHasher passwordHasher)
        {
            this.passwordHasher = passwordHasher;
        }

        public async Task<Guid> CreateManagerAsync(IContext context, CreateManagerCommand request, CancellationToken cancellationToken)
        {
            if (await context.Managers.FirstOrDefaultAsync(m => m.Email == request.Email, cancellationToken) != null)
                throw new AlreadyCreatedException(request.Email); 
            Guid id = Guid.NewGuid();
            var hashedpassword = passwordHasher.Generate(request.Password);
            await context.Managers.AddAsync(new Manager
            {
                Id = id,
                Name = request.Name,
                Email = request.Email,
                Password = hashedpassword,
                PhoneNumber = request.PhoneNubmer,
            }, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return id;
        }

        public async Task DeleteManagerAsync(IContext context, Guid id, CancellationToken cancellationToken)
        {
            var manager = await context.Managers.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (manager == null || manager.Id != id)
                throw new NotFoundException(id);

            context.Managers.Remove(manager);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Manager>> GetAllManagersAsync(IContext context, CancellationToken cancellationToken)
        {
            var managers = await context.Managers.ToListAsync(cancellationToken);
            if (managers.Count == 0)
                throw new NotFoundException();
            return (managers);
        }

        public async Task<Manager> GetManagerAsync(IContext context, Guid id, CancellationToken cancellationToken)
        {
            var manager = await context.Managers.FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

            if (manager == null || manager.Id != id)
                throw new NotFoundException(id);
            return manager;
        }

        public async Task<Manager> GetManagerByEmailAsync(IContext context, string email, CancellationToken cancellationToken)
        {
            var manager = await context.Managers.FirstOrDefaultAsync(m => m.Email == email, cancellationToken);

            if (manager == null || manager.Email != email)
                throw new NotFoundException();
            return manager;
        }

        public async Task<Guid> LoginManagerAsync(IContext context, LoginManagerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var manager = await GetManagerByEmailAsync(context, request.Email, cancellationToken);
                var result = passwordHasher.Verify(request.Password, manager.Password);
                if (result == false)
                    throw new ValidationException("Wrong passwod or Email");
                return manager.Id;
            }
            catch
            {
                throw new ValidationException("Wrong passwod or Email");
            }
        }

        public async Task<Guid> UpdateManagerAsync(IContext context, UpdateManagerCommand request, CancellationToken cancellationToken)
        {
            var manager = await context.Managers.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            if (manager == null || manager.Id != request.Id)
                throw new NotFoundException(request.Id);

            manager.Name = request.Name ?? manager.Name;
            manager.Email = request.Email ?? manager.Email;
            manager.PhoneNumber = request.PhoneNumber ?? manager.PhoneNumber;
            await context.SaveChangesAsync(cancellationToken);

            return manager.Id;
        }
    }
}
