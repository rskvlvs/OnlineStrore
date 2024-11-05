using FluentValidation;
using MediatR;

namespace OnlineStore.Logic.Commands.Manager.Login
{
    public class LoginManagerCommand : IRequest<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginManagerCommandValidator : AbstractValidator<LoginManagerCommand>
    {
        public LoginManagerCommandValidator()
        {
            RuleFor(log => log.Email).NotEmpty().WithMessage("Field Email is required").EmailAddress().WithMessage("Invalid email format");
            RuleFor(log => log.Password).NotEmpty().WithMessage("Field Password is required");
        }

    }
}
