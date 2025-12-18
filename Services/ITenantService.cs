using BillingApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITenantService
{
    Task<int> Create(Tenant tenant);
    Task<int> Update(Tenant tenant);
    Task<int> Delete(int tenantId);
    Task<Tenant?> GetTenantById(int tenantId);
    Task<List<Tenant>> GetAllTenants();
}
