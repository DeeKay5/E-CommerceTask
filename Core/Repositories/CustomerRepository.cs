using AutoMapper;
using Core.Repositories.Interfaces;
using Infrastructure.Data;
using Infrastructure.DTOs;
using Infrastructure.Entities;

namespace Core.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CustomerRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Customer> Create(CustomerDTO customerDTO)
        {
            //In case our request contained an invalid ID, we must first wipe it.
            customerDTO.Id = 0;

            var customer = _mapper.Map<Customer>(customerDTO);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer;
        }
    }
}
