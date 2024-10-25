using MediatR;

namespace OnlineStrore.Logic.Commands.Manager.Delete
{
    public class DeleteManagerCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
