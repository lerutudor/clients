using Customers.Domain.Entities;

namespace Customers.Domain.Interfaces
{
    public interface ICustomerService
    {
        Customer Save(Customer customer);
    }
}
