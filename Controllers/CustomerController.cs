using BillingApp.Models;
using BillingApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BillingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("getAllCustomers")]
        public async Task<IActionResult> GetAllCustomers([FromQuery] int? page, [FromQuery] int? pageSize)
        {
            if (page.HasValue || pageSize.HasValue)
            {
                var p = page ?? 1;
                var ps = pageSize ?? 10;
                var result = await _customerService.GetAllCustomersPaged(p, ps);
                return Ok(result);
            }

            List<Customer> customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound("Customer not found");

            return Ok(customer);
        }

        [HttpPost]
        [Route("createCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _customerService.Create(customer);
            return result > 0 ? Ok(new { message = "Customer created successfully", id = customer.Id }) : BadRequest();
        }

        [HttpPut]
        [Route("updateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _customerService.Update(customer);
            return result > 0 ? Ok("Customer updated successfully") : NotFound();
        }

        [HttpDelete("deleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.Delete(id);
            return result > 0 ? Ok("Customer deleted successfully") : NotFound();
        }

    }
}
