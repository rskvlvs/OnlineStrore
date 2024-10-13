using MediatR;
using OnlineStore.Storage.MS_SQL;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Repositories.Interfaces;

namespace OnlineStrore.Commands.Client.Create
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Guid>
    {
        private IClientRepository clientRepository;
        private IContext context;
        public CreateClientCommandHandler(IClientRepository clientRepository, IContext _context)
            => (clientRepository, context) = (clientRepository, _context);

        public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            Guid id = await clientRepository.CreateClientAsync(context, request, cancellationToken);
            return id;
        }
    }
}
