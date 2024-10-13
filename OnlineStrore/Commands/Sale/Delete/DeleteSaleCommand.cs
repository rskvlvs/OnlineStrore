using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Commands.Sale.Delete
{
    public class DeleteSaleCommand : IRequest 
    {
        [Required]
        public Guid Id { get; set; }
    }
}
