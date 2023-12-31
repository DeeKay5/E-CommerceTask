﻿namespace Infrastructure.Entities
{
    public class OrderProduct
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public Product Product { get; set; } = null!;

        public Order Order { get; set; } = null!;
    }
}
