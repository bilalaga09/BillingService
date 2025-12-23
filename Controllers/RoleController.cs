using BillingApp.Models;
using BillingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BillingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("getAllRoles/{tenantId:int}")]
        public async Task<ActionResult<List<Role>>> GetAllRoles(int tenantId)
        {
            var roles = await _roleService.GetAllRoles(tenantId);
            return Ok(roles);
        }

        [HttpGet("getById{id:int}")]
        public async Task<ActionResult<Role>> GetRoleById(int id)
        {
            var role = await _roleService.GetRoleById(id);
            if (role == null)
                return NotFound();

            return Ok(role);
        }

        [HttpPost("createRole")]
        public async Task<ActionResult<int>> CreateRole([FromBody] Role role)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var result = await _roleService.Create(role);
            return Ok(result);
        }

        [HttpPut("updateRole")]
        public async Task<ActionResult<int>> UpdateRole([FromBody] Role role)
        {
            var result = await _roleService.Update(role);
            if (result == 0)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("deleteRole/{id:int}")]
        public async Task<ActionResult<int>> DeleteRole(int id)
        {
            var result = await _roleService.Delete(id);
            if (result == 0)
                return NotFound();

            return Ok(result);
        }
    }
}
