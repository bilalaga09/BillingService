using BillingApp.Context;
using BillingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingApp.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly BillingDbContext _billingDbContext;

        public RoleRepository(BillingDbContext billingDbContext)
        {
            _billingDbContext = billingDbContext;
        }

        public async Task<List<Role>> GetAllRoles(int tenantId)
        {
            return await _billingDbContext.Roles
                .AsNoTracking()
                .Where(x => x.TenantId == tenantId && x.Active == 'Y')
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Role?> GetRoleById(int id)
        {
            return await _billingDbContext.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && x.Active == 'Y');
        }

        public async Task<int> Create(Role role)
        {
            role.CreatedAt = DateTime.Now;
            role.Active = 'Y';

            _billingDbContext.Roles.Add(role);
            return await _billingDbContext.SaveChangesAsync();
        }

        public async Task<int> Update(Role role)
        {
            _billingDbContext.Roles.Update(role);
            return await _billingDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var role = await _billingDbContext.Roles.FindAsync(id);
            if (role == null) return 0;

            role.Active = 'N'; // Soft delete
            return await _billingDbContext.SaveChangesAsync();
        }
    }
}
