using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.Product.Update
{
    public class UpdateProductCommand : IRequest<Guid>
    {
        [Required]
        public Guid Id { get; set; } //По которому буду искать

        [MaxLength(255)]
        public string Name { get; set; }

        public uint? Cost {  get; set; }

        public uint? CountOfProduct {  get; set; }
    }
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator() 
        {
            RuleFor(UpdateProductCommand => UpdateProductCommand.Id).NotEqual(Guid.Empty);
            RuleFor(UpdateProductCommand => UpdateProductCommand.Name).MaximumLength(255);
        }
    }
}
