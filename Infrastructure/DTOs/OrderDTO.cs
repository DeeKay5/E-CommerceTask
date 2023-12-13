using Infrastructure.Entities;

namespace Infrastructure.DTOs
{
    public class OrderDTO
    {
        public CustomerDTO Customer { get; set; }

        public List<ProductDTO> Products { get; set; } = new();
    }
}
