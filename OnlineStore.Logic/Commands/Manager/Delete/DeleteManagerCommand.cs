using FluentValidation;
using MediatR;

namespace OnlineStrore.Logic.Commands.Manager.Delete
{
    public class DeleteManagerCommand : IRequest
    {
        public Guid Id { get; set; }
    }
    public class DeleteManagerCommandValidator : AbstractValidator<DeleteManagerCommand>
    {
        public DeleteManagerCommandValidator()
        {
            RuleFor(DeleteManagerCommand => DeleteManagerCommand.Id).NotEqual(Guid.Empty).WithMessage("Id field is required");
        }
    }
}
