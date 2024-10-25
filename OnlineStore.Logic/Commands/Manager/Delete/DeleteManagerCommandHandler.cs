using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Commands.Manager.Delete
{
    public class DeleteManagerCommandHandler : IRequest<DeleteManagerCommand>
    {
        private IManagerRepository managerRepository;
        private IContext context;
        public DeleteManagerCommandHandler(IManagerRepository _managerRepository, IContext _context)
            => (managerRepository, context) = (_managerRepository, _context);
        public async Task Handle(DeleteManagerCommand request, CancellationToken cancellationToken)
        {
            await managerRepository.DeleteManagerAsync(context, request.Id, cancellationToken);
        }
    }
}
