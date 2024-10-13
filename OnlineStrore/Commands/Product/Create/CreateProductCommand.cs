using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Commands.Product.Create
{
    public class CreateProductCommand : IRequest<Guid>
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public uint Cost { get; set; }

        [Required, MaxLength(255)]
        public uint CountOfProduct {  get; set; }

        public Guid? ProductTypeId { get; set; }

    }
}
