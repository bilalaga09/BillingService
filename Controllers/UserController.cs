using BillingApp.Models;
using BillingApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BillingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("getAllUsers/{tenantId:int}")]
        public async Task<ActionResult<List<User>>> GetAllUsers(int tenantId)
        {
            var users = await _userService.GetAllUsers(tenantId);
            return Ok(users);
        }

        // 🔹 Get user by Id
        [HttpGet("getById{id:int}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // 🔹 Get user by username (tenant scoped)
        [HttpGet("getByUserName")]
        public async Task<ActionResult<User>> GetByUserName(
            [FromQuery] int tenantId,
            [FromQuery] string userName)
        {
            var user = await _userService.GetByUserName(tenantId, userName);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // 🔹 Create user
        [HttpPost("createUser")]
        public async Task<ActionResult<int>> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Create(user);
            return Ok(result);
        }

        // 🔹 Update user
        [HttpPut("updateUser")]
        public async Task<ActionResult<int>> UpdateUser([FromBody] User user)
        {
            var result = await _userService.Update(user);
            if (result == 0)
                return NotFound();

            return Ok(result);
        }

        // 🔹 Soft delete user
        [HttpDelete("deleteUser/{id:int}")]
        public async Task<ActionResult<int>> DeleteUser(int id)
        {
            var result = await _userService.Delete(id);
            if (result == 0)
                return NotFound();

            return Ok(result);
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLogin login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = await _userService.Login(login);
            if (token == null)
                return Unauthorized("Invalid username or password");

            return Ok(new { token });
        }

        // 🔹 Change password
        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userName = request.Username;
            var changed = await _userService.ChangePassword(userName, request);
            if (!changed)
                return BadRequest("Current password is incorrect or user not found.");

            return NoContent();
        }
    }
}
