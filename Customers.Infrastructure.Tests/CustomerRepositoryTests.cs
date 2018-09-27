using Customers.Domain.Entities;
using Customers.Infrastructure.Models;
using Customers.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Customers.Infrastructure.Tests
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        private CustomerRepository customerRepository;
        private CustomerDbContext context;
        private DbSet<CustomerDataModel> customerCollection;
        private Customer customerForSave = new Customer()
        {
            Email = "test@test.com",
            Id = 1,
            Name = "test"
        };

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>()
              .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
              .Options;
            context = new CustomerDbContext(options);
            context.Database.EnsureDeleted();
            customerRepository = new CustomerRepository(context);
            customerCollection = context.Set<CustomerDataModel>();
        }

        [TestMethod]
        public void Add_WhenCustomersAreAdded_NewCustomerIsAddedToDb()
        {
            //Act
            customerRepository.Add(customerForSave);

            //Assert
            Assert.IsTrue(customerCollection.Count() > 0);
        }

        [TestMethod]
        public void Add_WhenCustomersAreAdded_NewCustomerIsAddedToDbAndHasCorrectInfo()
        {
            //Act
            customerRepository.Add(customerForSave);

            //Assert
            var customerFromDb = customerCollection.FirstOrDefault(x => x.Email.Equals("test@test.com"));
            Assert.AreEqual("test@test.com", customerFromDb.Email);
            Assert.AreEqual("test", customerFromDb.Name);
        }

        [TestMethod]
        public void Add_WhenCustomersAreAdded_NewCustomerIsAddedToDbAndReturnsIt()
        {
            //Act
            var returnedCustomer = customerRepository.Add(customerForSave);

            //Assert
            Assert.AreEqual("test@test.com", returnedCustomer.Email);
            Assert.AreEqual("test", returnedCustomer.Name);
        }

        [TestMethod]
        public void GetByEmail_WhenCustomersAreSearchedByEmail_IfThereIsAnyCustomerIsReturned()
        {
            //Arrange
            customerRepository.Add(customerForSave);

            //Act
            var resultCustomer = customerRepository.GetByEmail("test@test.com");

            //Assert
            Assert.IsNotNull(resultCustomer);
            Assert.AreEqual("test@test.com", resultCustomer.Email);
            Assert.AreEqual("test", resultCustomer.Name);
        }

        [TestMethod]
        public void GetByEmail_WhenCustomersAreSearchedByEmail_IfThereIsNoCustomerIsNotReturned()
        {
            //Act
            var resultCustomer = customerRepository.GetByEmail("test@test.com");

            //Assert
            Assert.IsNull(resultCustomer);
        }

        [TestMethod]
        public void Update_WhenCustomersAreUpdated_ItExistsInDb()
        {
            //Arrange
            customerRepository.Add(customerForSave);

            //Act
            customerRepository.Update(new Customer() { Id = 1,Email = "test@test.com",Name = "newName"});

            //Assert
            var customerFromDb = customerCollection.FirstOrDefault(x => x.Email.Equals("test@test.com"));
            Assert.IsNotNull(customerFromDb);
        }

        [TestMethod]
        public void Update_WhenCustomersAreUpdated_ItHasCorrectInformation()
        {
            //Arrange
            customerRepository.Add(customerForSave);

            //Act
            customerRepository.Update(new Customer() { Id = 1, Email = "test@test.com", Name = "newName" });

            //Assert
            var customerFromDb = customerCollection.FirstOrDefault(x => x.Email.Equals("test@test.com"));
            Assert.AreEqual("newName",customerFromDb.Name);
        }
    }
}
