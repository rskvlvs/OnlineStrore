﻿using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Commands.Client.Update;
using OnlineStrore.Repositories.Interfaces;

namespace OnlineStrore.Commands.Manager.Update
{
    public class UpdateManagerCommandHandler: IRequestHandler<UpdateManagerCommand, Guid>
    {
        private IManagerRepository managerRepository;
        private IContext context;
        public UpdateManagerCommandHandler(IManagerRepository _managerRepository, IContext _context)
            => (managerRepository, context) = (_managerRepository, _context);

        public async Task<Guid> Handle(UpdateManagerCommand request, CancellationToken cancellationToken)
        {
            Guid id = await managerRepository.UpdateManagerAsync(context, request, cancellationToken);
            return id;
        }
    }
}
