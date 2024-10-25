using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.Manager.Update
{
    public class UpdateManagerCommand : IRequest<Guid>
    {
        public Guid Id { get; set; } //Айдишник, по которому надо искать

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
