using Microsoft.EntityFrameworkCore;

namespace Customers.Infrastructure.Models
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public DbSet<CustomerDataModel> Customers { get; set; }
    }
}
