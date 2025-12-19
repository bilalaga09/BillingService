using BillingApp.Models;
using BillingApp.Repository;

namespace BillingApp.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<int> Create(Tenant tenant)
        {
            return await _tenantRepository.Create(tenant);
        }

        public async Task<List<Tenant>> GetAllTenants()
        {
            var tenants = await _tenantRepository.GetAllTenants();
            return tenants;
        }

        public async Task<Tenant?> GetTenantById(int tenantId)
        {
            var tenant = await _tenantRepository.GetTenantById(tenantId);
            if (tenant == null) return null;

            return tenant;
        }

        public async Task<int> Update(Tenant tenant)
        {
            var existingTenant = await _tenantRepository.GetTenantById(tenant.Id);
            if (existingTenant == null) return 0;

            return await _tenantRepository.Update(tenant);
        }

        public async Task<int> Delete(int tenantId)
        {
            return await _tenantRepository.Delete(tenantId);
        }
    }
}
