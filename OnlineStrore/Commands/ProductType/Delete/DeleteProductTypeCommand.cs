using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Commands.ProductType.Delete
{
    public class DeleteProductTypeCommand : IRequest 
    {
        [Required]
        public Guid Id { get; set; }
    }
}
