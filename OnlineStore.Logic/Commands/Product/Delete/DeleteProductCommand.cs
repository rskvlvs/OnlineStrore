using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.Product.Delete
{
    public class DeleteProductCommand : IRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
