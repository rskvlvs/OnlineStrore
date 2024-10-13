using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Commands.Client.Create;
using OnlineStrore.Commands.Client.Update;

namespace OnlineStrore.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllClientsAsync(IContext context);

        Task<Client> GetClientAsync(IContext context, Guid id);

        Task<Guid> CreateClientAsync(IContext context, CreateClientCommand request, CancellationToken cancellationToken);

        Task<Guid> UpdateClientAsync(IContext context, UpdateClientCommand request, CancellationToken cancellationToken);

        Task DeleteClientAsync(IContext context, Guid id, CancellationToken cancellationToken);


    }
}
