using BillingApp.Models;
using BillingApp.Repository;

namespace BillingApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<int> Create(User user)
        {
            // Server-controlled fields
            user.Id = 0;
            user.Active = 'Y';
            user.CreatedAt = DateTime.Now;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

            return await _userRepository.Create(user);
        }

        public async Task<List<User>> GetAllUsers(int tenantId)
        {
            return await _userRepository.GetAllUsers(tenantId);
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User?> GetByUserName(int tenantId, string userName)
        {
            return await _userRepository.GetByUserName(tenantId, userName);
        }

        public async Task<int> Update(User updatedUser)
        {
            var existingUser = await _userRepository.GetUserById(updatedUser.Id);
            if (existingUser == null) return 0;

            // Preserve protected fields
            updatedUser.CreatedAt = existingUser.CreatedAt;
            updatedUser.Active = existingUser.Active;
            updatedUser.TenantId = existingUser.TenantId;

            return await _userRepository.Update(updatedUser);
        }

        public async Task<int> Delete(int id)
        {
            return await _userRepository.Delete(id);
        }
        public async Task<string?> Login(UserLogin login)
        {
            var user = await _userRepository.Login(login.Email);
            if (user == null)
                return null;

            // 🔐 Password verification
            if (!BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash))
                return null;

            // 🎫 Generate JWT
            return _tokenGenerator.GenerateToken(
                user.Id,
                user.UserName,
                user.TenantId,
                user.RoleId
            );
        }
    }
}
