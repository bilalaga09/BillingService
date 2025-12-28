using BillingApp.Models;

namespace BillingApp.Services
{
    public interface IUserService
    {
        Task<int> Create(User user);
        Task<int> Update(User user);
        Task<int> Delete(int id);
        Task<User?> GetUserById(int id);
        Task<List<User>> GetAllUsers(int tenantId);
        Task<User?> GetByUserName(int tenantId, string userName);
        Task<string?> Login(UserLogin login);
        Task<bool> ChangePassword(string userName, ChangePasswordRequest request);

    }
}
