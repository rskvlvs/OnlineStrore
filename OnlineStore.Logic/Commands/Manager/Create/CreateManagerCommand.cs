using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.Manager.Create
{
    public class CreateManagerCommand : IRequest<Guid>
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(255)]
        public string Password { get; set; }

        [Required, Phone]
        public string PhoneNubmer { get; set; }
    }
    public class CreateManagerCommandValidator : AbstractValidator<CreateManagerCommand>
    {
        public CreateManagerCommandValidator()
        {
            RuleFor(CreateManagerCommand => CreateManagerCommand.Name).NotEmpty().MaximumLength(255);
            RuleFor(CreateManagerCommand => CreateManagerCommand.Email).NotEmpty().EmailAddress();
            RuleFor(CreateManagerCommand => CreateManagerCommand.Password).NotEmpty().MaximumLength(255);
            RuleFor(CreateManagerCommand => CreateManagerCommand.PhoneNubmer).NotEmpty();
        }

    }
}
