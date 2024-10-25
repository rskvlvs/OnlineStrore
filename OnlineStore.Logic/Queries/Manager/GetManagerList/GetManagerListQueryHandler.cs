using AutoMapper;
using MediatR;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStrore.Logic.Repositories.Interfaces;

namespace OnlineStrore.Logic.Queries.Manager.GetManagerList
{
    public class GetManagerListQueryHandler : IRequestHandler<GetManagerListQuery, ManagerListVm>
    {
        private IManagerRepository managerRepository;
        private IContext context;
        private IMapper mapper;

        public GetManagerListQueryHandler(IManagerRepository managerRepository, IContext context, IMapper mapper)
        {
            this.managerRepository = managerRepository;
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<ManagerListVm> Handle(GetManagerListQuery request, CancellationToken cancellationToken)
        {
            var managers = await managerRepository.GetAllManagersAsync(context, cancellationToken);

            var managerDtos = mapper.Map<List<ManagerLookUpDto>>(managers); 

            return new ManagerListVm { Managers = managerDtos };
        }
    }
}
