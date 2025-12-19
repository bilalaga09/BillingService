using BillingApp.Models;
using BillingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BillingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet("getAllTenants")]
        public async Task<ActionResult<List<Tenant>>> GetAllTenants()
        {
            var tenants = await _tenantService.GetAllTenants();
            return Ok(tenants);
        }

        [HttpGet("getById{id:int}")]
        public async Task<ActionResult<Tenant>> GetTenantById(int id)
        {
            var tenant = await _tenantService.GetTenantById(id);
            if (tenant == null)
                return NotFound();

            return Ok(tenant);
        }

        [HttpPost("createTenant")]
        public async Task<ActionResult<int>> CreateTenant([FromBody] Tenant tenant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _tenantService.Create(tenant);
            return Ok(result);
        }

        [HttpPut("updateTenant")]
        public async Task<ActionResult<int>> UpdateTenant( [FromBody] Tenant tenant)
        {
            var result = await _tenantService.Update(tenant);
            if (result == 0)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("deleteTenant/{id:int}")]
        public async Task<ActionResult<int>> DeleteTenant(int id)
        {
            var result = await _tenantService.Delete(id);
            if (result == 0)
                return NotFound();

            return Ok(result);
        }
    }
}
