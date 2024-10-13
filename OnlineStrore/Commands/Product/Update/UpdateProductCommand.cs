using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Commands.Product.Update
{
    public class UpdateProductCommand : IRequest<Guid>
    {
        [Required]
        public Guid Id { get; set; } //По которому буду искать

        public string Name { get; set; }

        public uint? Cost {  get; set; }

        public uint? CountOfProduct {  get; set; }
    }
}
