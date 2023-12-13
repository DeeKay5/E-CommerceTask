using Infrastructure.DTOs;
using Infrastructure.Entities;

namespace Core.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> Create(CustomerDTO customerDTO);
    }
}
