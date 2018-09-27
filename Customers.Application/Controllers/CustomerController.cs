using System;
using Customers.Domain.Entities;
using Customers.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("Save")]
        public IActionResult Save([FromBody]Customer saveParameter)
        {
            try
            {
                var customer = _customerService.Save(saveParameter);

                return Ok(customer);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
