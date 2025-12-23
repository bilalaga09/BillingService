using BillingApp.Models;

namespace BillingApp.Repository
{
    public interface ITenantRepository
    {
        Task<int> Create(Tenant tenant);
        Task<int> Update(Tenant tenant);
        Task<int> Delete(int tenantId);
        Task<Tenant?> GetTenantById(int tenantId);
        Task<List<Tenant>> GetAllTenants();
    }
}
