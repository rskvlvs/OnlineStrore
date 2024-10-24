﻿using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Commands.Client.Create;
using OnlineStrore.Repositories.Interfaces;

namespace OnlineStrore.Commands.Manager.Create
{
    public class CreateManagerCommandHandler : IRequestHandler<CreateManagerCommand, Guid>
    {
        private IManagerRepository managerRepository;
        private IContext context;
        public CreateManagerCommandHandler(IManagerRepository _managerRepository, IContext _context)
            => (managerRepository, context) = (_managerRepository, _context);

        public async Task<Guid> Handle(CreateManagerCommand request, CancellationToken cancellationToken)
        {
            Guid id = await managerRepository.CreateManagerAsync(context, request, cancellationToken);
            return id;
        }
    }
}
