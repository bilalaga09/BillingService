using BillingApp.Models;

namespace BillingApp.Repository
{
    public interface IUserRepository
    {
        Task<int> Create(User user);
        Task<int> Update(User user);
        Task<int> Delete(int id);
        Task<User?> GetUserById(int id);
        Task<List<User>> GetAllUsers(int tenantId);
        Task<User?> GetByUserName(int tenantId, string userName);
        Task<User?> Login(string email);

    }
}
