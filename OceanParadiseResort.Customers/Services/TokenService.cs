using Microsoft.IdentityModel.Tokens;
using OceanParadiseResort.Customers.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OceanParadiseResort.Customers.Services
{
    public sealed class TokenService
    {
        public TokenService(IConfiguration config)
        {
            _configuration = config;
        }

        private IConfiguration _configuration;
        internal string Generate(Customer customer)
        {
            Claim[] claims = new Claim[3]
            {
                new Claim(ClaimTypes.Name, customer.UserName!),
                new Claim(ClaimTypes.Email, customer.Email!),
                new Claim(ClaimTypes.DateOfBirth, customer.Birthday.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricKey"]!));

            var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    claims: claims,
                    signingCredentials: signature,
                    expires: DateTime.Now.AddHours(2)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
