using AutoMapper;
using OnlineStore.Storage.MS_SQL;
using OnlineStrore.Logic.Queries.Manager.GetManager;
using OnlineStrore.Logic.Queries.Manager.GetManagerList;


namespace OnlineStrore.Logic.Mappers.ManagerMap
{
    public class ManagerMappingProfile: Profile
    {
        public ManagerMappingProfile() 
        {
            CreateMap<Manager, ManagerVm>()
                .ForMember(m => m.Name,
                src => src.MapFrom(src => src.Name))
                .ForMember(p => p.Email,
                src => src.MapFrom(src => src.Email))
                .ForMember(m => m.PhoneNumber,
                src => src.MapFrom(src => src.PhoneNumber));

            CreateMap<Manager, ManagerLookUpDto>()
                .ForMember(m => m.Id,
                src => src.MapFrom(src => src.Id));
        }
    }
}
