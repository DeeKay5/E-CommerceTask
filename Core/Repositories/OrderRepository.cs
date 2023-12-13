using AutoMapper;
using Core.Repositories.Interfaces;
using Infrastructure.Data;
using Infrastructure.DTOs;
using Infrastructure.Entities;

namespace Core.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public OrderRepository(ApplicationDbContext context, IMapper mapper, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _context = context;
            _mapper = mapper;
            _customerRepository = customerRepository;
            _productRepository = productRepository; 
        }

        /// <summary>
        /// Create the order by putting together the customer information, order details and associated products
        /// </summary>
        /// <param name="orderDTO"></param>
        /// <returns></returns>
        public async Task CreateAsync(OrderDTO orderDTO)
        {
            Customer customer = _mapper.Map<Customer>(orderDTO.Customer);

            //if the customer Id wasn't in the request object we're gonna assume it is a new customer, otherwise we check whether the customer exists and attach the order to the existing customer
            if(orderDTO.Customer.Id > 0)
            {
                var storedCustomer = _context.Customers.Find(orderDTO.Customer.Id);
                if(storedCustomer != null)
                {
                    customer = storedCustomer;
                }
                else
                {
                    customer = _mapper.Map<Customer>(await _customerRepository.Create(orderDTO.Customer));
                }
            }
            else
            {
                customer = _mapper.Map<Customer>(await _customerRepository.Create(orderDTO.Customer));
            }

            //Create and the order object and save to database to obtain the new order ID
            Order order = new Order
            {
                CustomerId = customer.Id
            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            List<OrderProduct> orderProducts = new List<OrderProduct>();

            foreach (var productDTO in orderDTO.Products)
            {
                Product product = await _productRepository.GetById(productDTO.Id);

                //ignore invalid product Ids
                if (product != null)
                {
                    //create the many-to-many records linking products and orders
                    for (int i = 1; i <= productDTO.Quantity; i++)
                    {
                        var orderProduct = new OrderProduct
                        {
                            Order = order,
                            Product = product,
                            ProductId = product.Id,
                            OrderId = order.Id
                        };
                        orderProducts.Add(orderProduct);
                    }
                }
            }
            order.OrderProducts = orderProducts;

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
