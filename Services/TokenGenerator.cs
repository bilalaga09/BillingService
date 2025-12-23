using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BillingApp.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        readonly IConfiguration _configuration;
        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(int userId,
            string userName,
            int tenantId,
            int roleId)
        {
            var claims = new[]
          {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, userName),
                new Claim("TenantId", tenantId.ToString()),
                new Claim("RoleId", roleId.ToString())
            };

            var secretKey = _configuration["JwtConfig:Key"];
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);

            var symmetricKey = new SymmetricSecurityKey(keyBytes);

            var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["JwtConfig:Issuer"],
                audience: _configuration["JwtConfig:Audience"],
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JwtConfig:TokenValidityMins"])),
                signingCredentials: signingCredentials,
                claims: claims
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

    }
}
