using MediatR;

namespace OnlineStrore.Commands.Client.Delete
{
    public class DeleteClientCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
