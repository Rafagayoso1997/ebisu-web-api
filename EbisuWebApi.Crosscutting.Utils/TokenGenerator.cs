﻿using Microsoft.IdentityModel.Tokens;
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
        public static string CreateToken(int id, string userName)
        {
            var claims = new List<Claim>
            {
                new Claim (ClaimTypes.NameIdentifier, id.ToString()),
                new Claim (ClaimTypes.Name, userName)
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

            var tokenHanlder = new JwtSecurityTokenHandler();

            var token = tokenHanlder.CreateToken(tokenDescriptor);

            return tokenHanlder.WriteToken(token);
        }
    }
}
