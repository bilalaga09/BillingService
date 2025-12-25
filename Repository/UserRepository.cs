using BillingApp.Context;
using BillingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BillingDbContext _billingDbContext;

        public UserRepository(BillingDbContext billingDbContext)
        {
            _billingDbContext = billingDbContext;
        }

        public async Task<List<User>> GetAllUsers(int tenantId)
        {
            return await _billingDbContext.Users
                .AsNoTracking()
                .Where(x => x.TenantId == tenantId && x.Active == 'Y')
                .OrderBy(x => x.UserName)
                .ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _billingDbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && x.Active == 'Y');
        }

        public async Task<User?> GetByUserName(int tenantId, string userName)
        {
            return await _billingDbContext.Users
                .FirstOrDefaultAsync(x =>
                    x.TenantId == tenantId &&
                    x.UserName == userName &&
                    x.Active == 'Y');
        }

        public async Task<int> Create(User user)
        {
            user.CreatedAt = DateTime.Now;
            user.Active = 'Y';

            _billingDbContext.Users.Add(user);
            return await _billingDbContext.SaveChangesAsync();
        }

        public async Task<int> Update(User user)
        {
            _billingDbContext.Users.Update(user);
            return await _billingDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var user = await _billingDbContext.Users.FindAsync(id);
            if (user == null) return 0;

            user.Active = 'N';
            return await _billingDbContext.SaveChangesAsync();
        }
        public async Task<User?> Login( string username)
        {
            return await _billingDbContext.Users
                .FirstOrDefaultAsync(x =>
                    x.UserName == username &&
                    x.Active == 'Y');
        }

    }
}
