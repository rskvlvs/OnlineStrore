﻿using Microsoft.EntityFrameworkCore;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Commands.Manager.Create;
using OnlineStrore.Commands.Manager.Update;
using OnlineStrore.Exceptions;
using OnlineStrore.Repositories.Interfaces;

namespace OnlineStrore.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        public async Task<Guid> CreateManagerAsync(IContext context, CreateManagerCommand request, CancellationToken cancellationToken)
        {
            if (context.Managers.FirstOrDefault(m => m.Email == request.Email) != null)
                throw new AlreadyCreatedException(request.Email); 
            Guid id = Guid.NewGuid();
            await context.Managers.AddAsync(new Manager
            {
                Id = id,
                Name = request.Name,
                Email = request.Email,
                Password = request.Password
            });
            await context.SaveChangesAsync(cancellationToken);
            return id;
        }

        public async Task DeleteManagerAsync(IContext context, Guid id, CancellationToken cancellationToken)
        {
            var manager = await context.Managers.FirstOrDefaultAsync(c => c.Id == id);
            if (manager == null || manager.Id != id)
                throw new NotFoundException(id);

            context.Managers.Remove(manager);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Manager>> GetAllManagersAsync(IContext context)
        {
            var managers = await context.Managers.ToListAsync();
            if (managers.Count == 0)
                throw new NotFoundException();
            return (managers);
        }

        public async Task<Manager> GetManagerAsync(IContext context, Guid id)
        {
            var manager = await context.Managers.FirstOrDefaultAsync(c => c.Id == id);

            if (manager == null || manager.Id != id)
                throw new NotFoundException(id);
            return manager;
        }

        public async Task<Guid> UpdateManagerAsync(IContext context, UpdateManagerCommand request, CancellationToken cancellationToken)
        {
            var manager = context.Managers.FirstOrDefault(c => c.Id == request.Id);
            if (manager == null || manager.Id != request.Id)
                throw new NotFoundException(request.Id);

            manager.Name = request.Name ?? manager.Name;
            manager.Email = request.Email ?? manager.Email;
            await context.SaveChangesAsync(cancellationToken);

            return manager.Id;
        }
    }
}
