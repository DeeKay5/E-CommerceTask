using Infrastructure.DTOs;

namespace Core.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateAsync(OrderDTO order);

    }
}
