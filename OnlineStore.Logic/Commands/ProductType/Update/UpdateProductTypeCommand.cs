using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.ProductType.Update
{
    public class UpdateProductTypeCommand : IRequest <Guid>
    {
        [Required] 
        public Guid Id { get; set; } // По которому искать

        [MaxLength(255)]
        public string Name { get; set; }
    }
    public class UpdateProductTypeCommandValidator : AbstractValidator<UpdateProductTypeCommand>
    {
        public UpdateProductTypeCommandValidator()
        {
            RuleFor(UpdateProductTypeCommand => UpdateProductTypeCommand.Id).NotEqual(Guid.Empty);
            RuleFor(UpdateProductTypeCommand => UpdateProductTypeCommand.Name).MaximumLength(255);
        }
    }
}
