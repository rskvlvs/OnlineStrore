using OnlineStore.Logic.Extensions;

namespace OnlineStrore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWebServices(this IServiceCollection service)
        {
            service.AddLogicServices();
        }
    }
}
