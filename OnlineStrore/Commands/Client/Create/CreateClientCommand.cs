using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Commands.Client.Create
{
    public class CreateClientCommand : IRequest<Guid>
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength (255)]
        public string Password { get; set; }
    }
}
