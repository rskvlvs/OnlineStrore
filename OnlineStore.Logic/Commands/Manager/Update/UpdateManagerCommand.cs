using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.Manager.Update
{
    public class UpdateManagerCommand : IRequest<Guid>
    {
        [Required]
        public Guid Id { get; set; } //Айдишник, по которому надо искать

        [MaxLength(255)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber {  get; set; }
    }
    public class UpdateManagerValidator : AbstractValidator<UpdateManagerCommand>
    {
        public UpdateManagerValidator() 
        {
            RuleFor(UpdateManagerCommand => UpdateManagerCommand.Id).NotEqual(Guid.Empty);
            RuleFor(UpdateManagerCommand => UpdateManagerCommand.Name).MaximumLength(255);
            RuleFor(UpdateManagerCommand => UpdateManagerCommand.Email).EmailAddress();
        }
    }
}
