using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrore.Logic.Commands.ProductType.Update
{
    public class UpdateProductTypeCommand : IRequest <Guid>
    {
        [Required] 
        public Guid Id { get; set; } // По которому искать

        public string Name { get; set; }
    }
}
