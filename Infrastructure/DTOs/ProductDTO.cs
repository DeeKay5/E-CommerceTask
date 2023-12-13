using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public int Quantity { get; set; }
    }
}
