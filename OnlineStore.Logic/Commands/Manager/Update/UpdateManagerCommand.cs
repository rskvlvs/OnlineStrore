using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.Manager.Update
{
    public class UpdateManagerCommand : IRequest<Guid>
    {
        public Guid Id { get; set; } //Айдишник, по которому надо искать

        [MaxLength(255)]
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber {  get; set; }
    }
    public class UpdateManagerValidator : AbstractValidator<UpdateManagerCommand>
    {
        public UpdateManagerValidator() 
        {
            RuleFor(UpdateManagerCommand => UpdateManagerCommand.Id).NotEqual(Guid.Empty).WithMessage("ManagerId field is required");

            // Проверка, что хотя бы одно из полей заполнено
            RuleFor(command => command)
                .Must(command => !string.IsNullOrWhiteSpace(command.Name) ||
                                 !string.IsNullOrWhiteSpace(command.Email) ||
                                 !string.IsNullOrWhiteSpace(command.PhoneNumber))
                .WithMessage("At least one of the fields (Name, Email, PhoneNumber) must be provided.");

            // Проверка формата email, только если поле не пустое
            RuleFor(command => command.Email)
                .EmailAddress()
                .When(command => !string.IsNullOrWhiteSpace(command.Email))
                .WithMessage("Invalid email format.");

            // Проверка формата телефона, только если поле не пустое
            RuleFor(command => command.PhoneNumber)
                .Matches(@"^\+?\d{10,15}$") // Пример проверки формата телефона
                .When(command => !string.IsNullOrWhiteSpace(command.PhoneNumber))
                .WithMessage("Invalid phone number format.");
        }
    }
}
