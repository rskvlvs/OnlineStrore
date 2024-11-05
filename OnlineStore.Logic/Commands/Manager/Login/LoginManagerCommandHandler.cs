using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Logic.Commands.Manager.Login
{
    public class LoginManagerCommandHandler : IRequestHandler<LoginManagerCommand, Guid>
    {
        private IManagerRepository managerRepository;
        private IContext context;
        public LoginManagerCommandHandler(IManagerRepository _managerRepository, IContext _context)
            => (managerRepository, context) = (_managerRepository, _context);
        
        public async Task<Guid> Handle(LoginManagerCommand request, CancellationToken cancellationToken)
        {
            var id = await managerRepository.LoginManagerAsync(context, request, cancellationToken);
            return id;
        }
    }
}
