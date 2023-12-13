using Infrastructure.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [Name]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string FirstName { get; set; }

        [Required]
        [Name]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public List<Order> Orders { get; set; } = new();
    }
}
