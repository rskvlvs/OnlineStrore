using Microsoft.EntityFrameworkCore.Update.Internal;
using OnlineStore.Logic.Commands.Manager.Login;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Commands.Manager.Create;
using OnlineStrore.Logic.Commands.Manager.Update;


namespace OnlineStrore.Logic.Repositories.Interfaces
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Manager>> GetAllManagersAsync(IContext context, CancellationToken cancellationToken);

        Task<Manager> GetManagerAsync(IContext context, Guid id, CancellationToken cancellationToken);
        Task<Manager> GetManagerByEmailAsync(IContext context, string email, CancellationToken cancellationToken);
        
        Task<Guid> LoginManagerAsync(IContext context, LoginManagerCommand request, CancellationToken cancellationToken);

        Task<Guid> CreateManagerAsync(IContext context, CreateManagerCommand request, CancellationToken cancellationToken);

        Task<Guid> UpdateManagerAsync(IContext context, UpdateManagerCommand request, CancellationToken cancellationToken);

        Task DeleteManagerAsync(IContext context, Guid id, CancellationToken cancellationToken);
    }
}
