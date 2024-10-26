using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.Product.Delete
{
    public class DeleteProductCommand : IRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator() 
        {
            RuleFor(DeleteProductCommand => DeleteProductCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
