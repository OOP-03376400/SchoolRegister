using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SchoolRegister.Infrastructure.DTO;
using SchoolRegister.Infrastructure.Extensions;
using SchoolRegister.Infrastructure.Settings;

namespace SchoolRegister.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _settings;

        public JwtHandler(JwtSettings settings)
        {
            _settings = settings;
        }

        public JwtDto CreateToken(Guid UserId, string role)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,UserId.ToString() ),
                new Claim(JwtRegisteredClaimNames.UniqueName, UserId.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString(), ClaimValueTypes.Integer64)
            };

            var expires = now.AddMinutes(_settings.ExpiryMinutes);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key)), 
                SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                issuer: _settings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDto
            {
                Token = token,
                Expires = expires.ToTimestamp()
            };
        }
    }
}