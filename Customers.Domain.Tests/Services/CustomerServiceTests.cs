using Customers.Domain.Entities;
using Customers.Domain.Intefaces;
using Customers.Domain.Interfaces;
using Customers.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Customers.Domain.Tests.Services
{
    [TestClass]
    public class CustomerServiceTests
    {
        private ICustomerService customerService;
        private Mock<ICustomerRepository> customerRepository;

        private readonly Customer customer = new Customer()
        {
            Email = "test@test.com",
            Id = 1,
            Name = "test"
        };

        private readonly Customer resultCustomer = new Customer()
        {
            Email = "test1@test.com",
            Id = 1,
            Name = "test1"
        };

        [TestInitialize]
        public void TestInitialize()
        {
            customerRepository = new Mock<ICustomerRepository>();
        }

        [TestMethod]
        public void WhenSaveIsCalled_IfCustomerDoesNotExistShouldCallAddMethod()
        {
            //arrange
            customerRepository.Setup(x => x.GetByEmail(It.IsAny<string>()));
            customerRepository.Setup(x => x.Add(It.IsAny<Customer>())).Returns(resultCustomer);
            customerService = new CustomerService(customerRepository.Object);

            //act
            var result = customerService.Save(customer);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("test1@test.com", result.Email);
            Assert.AreEqual("test1", result.Name);
            customerRepository.Verify(x =>x.Add(It.IsAny<Customer>()),Times.Once());
        }

        [TestMethod]
        public void WhenSaveIsCalled_IfCustomerDoesExistShouldCallUpdateMethod()
        {
            //arrange
            customerRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns(customer);
            customerRepository.Setup(x => x.Update(It.IsAny<Customer>())).Returns(resultCustomer);
            customerService = new CustomerService(customerRepository.Object);

            //act
            var result = customerService.Save(customer);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("test1@test.com", result.Email);
            Assert.AreEqual("test1", result.Name);
            customerRepository.Verify(x => x.Update(It.IsAny<Customer>()), Times.Once());
        }

        [TestMethod]
        public void WhenSaveIsCalled_IfUpdateIsCalledMakeSureIdIsSetToCustomer()
        {
            //arrange
            customerRepository.Setup(x => x.GetByEmail(It.IsAny<string>())).Returns(customer);
            Customer customerCalledForUpdate = new Customer();
            customerRepository.Setup(x => x.Update(It.IsAny<Customer>())).Callback<Customer>(r => customerCalledForUpdate = r);
            customerService = new CustomerService(customerRepository.Object);

            //act
            var result = customerService.Save(customer);

            //assert
            Assert.IsNotNull(customerCalledForUpdate);
            Assert.AreEqual(1, customerCalledForUpdate.Id);
        }
    }
}
