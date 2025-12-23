using BillingApp.Models;

namespace BillingApp.Repository
{
    public interface IRoleRepository
    {
        Task<int> Create(Role role);
        Task<int> Update(Role role);
        Task<int> Delete(int id);
        Task<Role?> GetRoleById(int id);
        Task<List<Role>> GetAllRoles(int tenantId);
    }
}
