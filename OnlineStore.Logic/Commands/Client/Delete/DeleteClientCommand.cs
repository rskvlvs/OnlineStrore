using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.Client.Delete
{
    public class DeleteClientCommand : IRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
    public class DeleteClientCommandValidator : AbstractValidator<DeleteClientCommand>
    {
        public DeleteClientCommandValidator() 
        {
            RuleFor(DeleteClientCommand =>
            DeleteClientCommand.Id).NotEqual(Guid.Empty); 
        }

    }
}
