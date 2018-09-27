using Customers.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Customers.Domain.Tests
{
    [TestClass]
    public class CustomerEntityTests
    {
        [TestMethod]
        public void WhenValidateIsCalled_ShouldNotBeErrorsIfCustomerIsValid()
        {
            Customer customer = new Customer()
            {
                Email = "test@test.com",
                Name = "test"
            };

            try
            {
                customer.Validate();
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "The Email field is required.")]
        public void WhenValidateIsCalled_ShouldThrowErrorWhenEmailIsNotSet()
        {
            Customer customer = new Customer()
            {
                Name = "test"
            };

            customer.Validate();
            Assert.Fail("no exception thrown");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The Email field is not in the correct format.")]
        public void WhenValidateIsCalled_ShouldThrowErrorWhenEmailIsInvalid()
        {
            Customer customer = new Customer()
            {
                Email = "test",
                Name = "test"
            };

            customer.Validate();
            Assert.Fail("no exception thrown");
        }
    }
}
