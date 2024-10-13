using MediatR;

namespace OnlineStrore.Commands.Manager.Delete
{
    public class DeleteManagerCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
