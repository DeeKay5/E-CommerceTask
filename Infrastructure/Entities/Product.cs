using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(2000)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public List<OrderProduct> OrderProducts { get; set; } = new();
    }
}
