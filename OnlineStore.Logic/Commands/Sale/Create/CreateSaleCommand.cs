using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.Sale.Create
{
    public class CreateSaleCommand : IRequest<Guid>
    {
        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public uint TotalSum { get; set; }
    }
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleCommandValidator()
        {
            RuleFor(CreateSaleCommand => CreateSaleCommand.ClientId).NotEqual(Guid.Empty);
            RuleFor(CreateSaleCommand => CreateSaleCommand.TotalSum).NotEmpty();
        }
    }
}
