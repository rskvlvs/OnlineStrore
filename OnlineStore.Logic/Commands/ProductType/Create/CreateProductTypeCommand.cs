using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.ProductType.Create
{
    public class CreateProductTypeCommand : IRequest <Guid>
    {
        [Required]
        public string Name { get; set; }
    }
}
