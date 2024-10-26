using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.Client.Update
{
    public class UpdateClientCommand : IRequest<Guid>
    {
        [Required]
        public Guid Id { get; set; } //Айдишник, по которому надо искать

        [MaxLength(255)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
    }
    public class UpdateClientCommandValidator: AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(UpdateClientCommand =>
            UpdateClientCommand.Id).NotEqual(Guid.Empty);
        }
    }

}
