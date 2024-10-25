using MediatR;

namespace OnlineStrore.Logic.Commands.Client.Delete
{
    public class DeleteClientCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
