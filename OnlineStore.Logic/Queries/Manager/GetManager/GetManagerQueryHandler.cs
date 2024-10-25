using AutoMapper;
using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Queries.Manager.GetManager
{
    public class GetManagerQueryHandler : IRequestHandler<GetManagerQuery, ManagerVm>
    {
        private IManagerRepository managerRepository;
        private IContext context;
        private IMapper mapper;

        public GetManagerQueryHandler(IMapper mapper, IContext context, IManagerRepository managerRepository)
        {
            this.mapper = mapper;
            this.context = context;
            this.managerRepository = managerRepository;
        }

        public async Task<ManagerVm> Handle(GetManagerQuery request, CancellationToken cancellationToken)
        {
            var manager = await managerRepository.GetManagerAsync(context, request.Id, cancellationToken);

            return mapper.Map<ManagerVm>(manager);  
        }

    }
}
