using Core.Repositories.Interfaces;
using Infrastructure.Data;
using Infrastructure.Entities;

namespace Core.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetById(int id) => await _context.Products.FindAsync(id);
    }
}
