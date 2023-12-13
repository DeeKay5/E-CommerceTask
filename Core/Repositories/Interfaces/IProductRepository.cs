using Infrastructure.Entities;

namespace Core.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetById(int id);
    }
}
