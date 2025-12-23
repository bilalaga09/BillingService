namespace BillingApp.Services
{
    public interface ITokenGenerator
    {
        string GenerateToken(int userId,
            string userName,
            int tenantId,
            int roleId);
    }
}
