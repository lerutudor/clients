using Customers.Domain.Entities;

namespace Customers.Domain.Intefaces
{
    public interface ICustomerRepository
    {
        Customer Add(Customer customer);
        Customer GetByEmail(string email);
        Customer Update(Customer customer);
    }
}
