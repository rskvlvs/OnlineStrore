using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Storage.MS_SQL
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public uint Cost { get; set; } = 0;

        [Required]
        public uint CountOfProduct { get; set; } = 0;

        public Guid ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public ICollection<Sale> Sales { get; set; }
        
    }
}
