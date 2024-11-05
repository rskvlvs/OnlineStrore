using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.Manager.Create
{
    public class CreateManagerCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        [Phone]
        public string PhoneNubmer { get; set; }
    }
    public class CreateManagerCommandValidator : AbstractValidator<CreateManagerCommand>
    {
        public CreateManagerCommandValidator()
        {
            RuleFor(CreateClientCommand =>
            CreateClientCommand.Name)
                .NotEmpty()
                .WithMessage("Name field is required")
                .MaximumLength(255)
                .WithMessage("Name field has maxLength 255");

            RuleFor(CreateClientCommand =>
            CreateClientCommand.Email)
                .NotEmpty()
                .WithMessage("Email field is required")
                .EmailAddress()
                .WithMessage("Invalid email format");

            RuleFor(CreateClientCommand =>
            CreateClientCommand.Password)
                .NotEmpty()
                .WithMessage("Password field is required")
                .MaximumLength(255)
                .WithMessage("Name field has maxLength 255");


            RuleFor(CreateClientCommand =>
            CreateClientCommand.PhoneNubmer).NotEmpty().WithMessage("PhoneNubmer field is required");
        }

    }
}
