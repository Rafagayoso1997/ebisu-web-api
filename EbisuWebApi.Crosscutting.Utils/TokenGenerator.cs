using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Crosscutting.Utils
{
    public class TokenGenerator
    {
        public static string CreateToken(int id, string userName, string email, Role role)
        {
            var claims = new List<Claim>
            {
                new Claim (ClaimTypes.NameIdentifier, id.ToString()),
                new Claim (ClaimTypes.Name, userName),
                new Claim (ClaimTypes.Email, email),
                new Claim (ClaimTypes.Role, role.ToString()),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY")));
            var expireTime = Convert.ToInt32(Environment.GetEnvironmentVariable("JWT_EXPIRE_MINUTES"));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
