using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.ProductType.Create
{
    public class CreateProductTypeCommand : IRequest <Guid>
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }
    }
    public class CreateProductTypeCommandValidator : AbstractValidator<CreateProductTypeCommand>
    {
        public CreateProductTypeCommandValidator()
        {
            RuleFor(CreateProductTypeCommand => CreateProductTypeCommand.Name).NotEmpty().MaximumLength(255);
        }
    }
}
