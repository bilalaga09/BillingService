using BillingApp.Models;
using BillingApp.Repository;

namespace BillingApp.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<int> Create(Role role)
        {
            // Server-controlled fields
            role.Id = 0;
            role.Active = 'Y';
            role.CreatedAt = DateTime.Now;

            return await _roleRepository.Create(role);
        }

        public async Task<List<Role>> GetAllRoles(int tenantId)
        {
            return await _roleRepository.GetAllRoles(tenantId);
        }

        public async Task<Role?> GetRoleById(int id)
        {
            return await _roleRepository.GetRoleById(id);
        }

        public async Task<int> Update(Role updatedRole)
        {
            var existingRole = await _roleRepository.GetRoleById(updatedRole.Id);
            if (existingRole == null) return 0;

            // Preserve server-controlled fields
            updatedRole.CreatedAt = existingRole.CreatedAt;
            updatedRole.Active = existingRole.Active;
            updatedRole.TenantId = existingRole.TenantId;

            return await _roleRepository.Update(updatedRole);
        }

        public async Task<int> Delete(int id)
        {
            return await _roleRepository.Delete(id);
        }
    }
}
