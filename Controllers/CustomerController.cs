using BillingApp.DTOs;
using BillingApp.Models;
using BillingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BillingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        [Route("getAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            List<CustomerDto> customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

    }
}
