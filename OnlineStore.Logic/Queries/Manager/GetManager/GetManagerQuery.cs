using MediatR;

namespace OnlineStrore.Logic.Queries.Manager.GetManager
{
    public class GetManagerQuery : IRequest<ManagerVm>
    {
        public Guid Id { get; set; }
    }
}
