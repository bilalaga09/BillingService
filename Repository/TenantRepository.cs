
using BillingApp.Context;
using BillingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingApp.Repository
{
    public class TenantRepository : ITenantRepository
    {
        readonly BillingDbContext _billingDbContext;
        public TenantRepository(BillingDbContext billingDbContext)
        {
            _billingDbContext = billingDbContext;
        }
        public async Task<int> Create(Tenant tenant)
        {
            tenant.CreatedAt = DateTime.Now;
            tenant.Active = 'Y';

            _billingDbContext.Tenants.Add(tenant);
            return await _billingDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var customer = await _billingDbContext.Tenants.FindAsync(id);
            if (customer == null) return 0;

            customer.Active = 'N';
            return await _billingDbContext.SaveChangesAsync();
        }

        public async Task<List<Tenant>> GetAllTenants()
        {
            return await _billingDbContext.Tenants
                .AsNoTracking()
                .Where(x => x.Active == 'Y')
                .ToListAsync();
        }

        public async Task<Tenant?> GetTenantById(int Id)
        {
            return await _billingDbContext.Tenants
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == Id && x.Active == 'Y');
        }

        public async Task<int> Update(Tenant tenant)
        {
            _billingDbContext.Tenants.Update(tenant);
            return await _billingDbContext.SaveChangesAsync();
        }
    }
}
