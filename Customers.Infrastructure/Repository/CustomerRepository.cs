using Customers.Domain.Entities;
using Customers.Domain.Intefaces;
using Customers.Infrastructure.Models;
using System.Linq;

namespace Customers.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public Customer GetByEmail(string email)
        {
            var existingCustomer = _context.Customers.FirstOrDefault(x => x.Email.Equals(email));

            if (null != existingCustomer)
                return new Customer()
                {
                    Email = existingCustomer.Email,
                    Id = existingCustomer.Id,
                    Name = existingCustomer.Name
                };

            return null;
        }

        public Customer Add(Customer customer)
        {
            CustomerDataModel model = new CustomerDataModel()
            {
                Email = customer.Email,
                Name = customer.Name
            };

            _context.Customers.Add(model);
            _context.SaveChanges();

            customer.Id = model.Id;

            return customer;
        }

        public Customer Update(Customer customer)
        {
            var existingCustomer = _context.Customers.FirstOrDefault(x => x.Email.Equals(customer.Email));
            existingCustomer.Name = customer.Name;

            _context.SaveChanges();

            return customer;
        }
    }
}
