using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Update.Internal;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Commands.Manager.Create;
using OnlineStrore.Commands.Manager.Update;


namespace OnlineStrore.Repositories.Interfaces
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Manager>> GetAllManagersAsync(IContext context);

        Task<Manager> GetManagerAsync(IContext context, Guid id);

        Task<Guid> CreateManagerAsync(IContext context, CreateManagerCommand request, CancellationToken cancellationToken);

        Task<Guid> UpdateManagerAsync(IContext context, UpdateManagerCommand request, CancellationToken cancellationToken);

        Task DeleteManagerAsync(IContext context, Guid id, CancellationToken cancellationToken);
    }
}
