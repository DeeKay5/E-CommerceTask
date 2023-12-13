using Infrastructure.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs
{
    public class CustomerDTO
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
    }
}
