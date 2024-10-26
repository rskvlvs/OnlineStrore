using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.Product.Create
{
    public class CreateProductCommand : IRequest<Guid>
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public uint Cost { get; set; }

        [Required]
        public uint CountOfProduct {  get; set; }

        public Guid? ProductTypeId { get; set; }

    }
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() 
        {
            RuleFor(CreateProductCommand => CreateProductCommand.Name).NotEmpty().MaximumLength(255);
            RuleFor(CreateProductCommand => CreateProductCommand.Cost).NotEmpty();
            RuleFor(CreateProductCommand => CreateProductCommand.CountOfProduct).NotEmpty();
        }
    }
}
