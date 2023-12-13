namespace Infrastructure.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<OrderProduct> OrderProducts { get; set; } = new();
    }
}
