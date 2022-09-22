using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Webapi.TokenOperations.Models;

namespace Webapi.TokenOperations
{
    public class JwtTokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public JwtTokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(int days = 0, int hours = 0, int minutes = 0, int seconds = 0)
        {
            Token token = new();

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Jwt:SecurityKey"]));

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            token.Expire = DateTime.Now
                .AddDays(days)
                .AddHours(hours)
                .AddMinutes(minutes)
                .AddSeconds(seconds);

            JwtSecurityToken jwtToken = new(
                audience: _configuration["Tokens:Jwt:Audience"],
                issuer: _configuration["Tokens:Jwt:Issuer"],
                signingCredentials: credentials,
                expires: token.Expire,
                notBefore: DateTime.Now
            );

            JwtSecurityTokenHandler handler = new();

            token.AccessToken = handler.WriteToken(jwtToken);

            return token;
        }
    }
}