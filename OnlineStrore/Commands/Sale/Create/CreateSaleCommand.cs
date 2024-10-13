using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Commands.Sale.Create
{
    public class CreateSaleCommand : IRequest<Guid>
    {
        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public uint TotalSum { get; set; }
    }
}
