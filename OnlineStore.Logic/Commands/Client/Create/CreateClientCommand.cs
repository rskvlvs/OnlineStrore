using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.Client.Create
{
    public class CreateClientCommand : IRequest<Guid>
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength (255)]
        public string Password { get; set; }

        [Required, Phone]
        public string PhoneNubmer {  get; set; }
    }
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(CreateClientCommand =>
            CreateClientCommand.Name).NotEmpty().MaximumLength(255);

            RuleFor(CreateClientCommand =>
            CreateClientCommand.Email).NotEmpty().EmailAddress();

            RuleFor(CreateClientCommand =>
            CreateClientCommand.Password).NotEmpty().MaximumLength(255);

            RuleFor(CreateClientCommand =>
            CreateClientCommand.PhoneNubmer).NotEmpty(); 
        }
    }
}
