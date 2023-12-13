using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Map the many-to-many relationship between Order and Product
            builder.Entity<OrderProduct>()
                .HasOne(x => x.Product)
                .WithMany(x => x.OrderProducts)
                .HasForeignKey(x => x.ProductId);

            builder.Entity<OrderProduct>()
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderProducts)
                .HasForeignKey(x => x.OrderId);

            //Seed some data with example products
            builder.Entity<Product>().HasData(new Product { Id = 1, Name = "Tie", Description = "This is an example description for a tie.", Price = Convert.ToDecimal(14.99) });
            builder.Entity<Product>().HasData(new Product { Id = 2, Name = "Trousers", Description = "This is an example description for trousers.", Price = Convert.ToDecimal(32.99) });
            builder.Entity<Product>().HasData(new Product { Id = 3, Name = "Shirt", Description = "This is an example description for a shirt.", Price = Convert.ToDecimal(20.99) });
            builder.Entity<Product>().HasData(new Product { Id = 4, Name = "Jacket", Description = "This is an example description for a jacket.", Price = Convert.ToDecimal(59.99) });
            builder.Entity<Product>().HasData(new Product { Id = 5, Name = "Belt", Description = "This is an example description for a belt.", Price = Convert.ToDecimal(9.99) });
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
