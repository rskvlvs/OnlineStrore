using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Commands.Product.Delete
{
    public class DeleteProductCommand : IRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
