using MediatR;

namespace OnlineStrore.Logic.Queries.Client.GetClient
{
    public class GetClientQuery : IRequest<ClientVm>
    {
        public Guid Id { get; set; }
    }
}
