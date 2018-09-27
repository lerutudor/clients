using Customers.Domain.Entities;
using Customers.Domain.Intefaces;
using Customers.Domain.Interfaces;

namespace Customers.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer Save(Customer customer)
        {
            customer.Validate();

            var existingCustomer = _customerRepository.GetByEmail(customer.Email);
            if(existingCustomer != null)
            {
                customer.Id = existingCustomer.Id;
                return _customerRepository.Update(customer);
            }
            else
            {
                return _customerRepository.Add(customer);
            }
        }
    }
}
