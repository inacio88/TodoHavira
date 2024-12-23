using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Todo.Api.Common;
using Todo.Core.Models;

namespace Todo.Api.Services
{
    public static class TokenService// : ITokenService
    {
        public static string Generate(User data)
        {
            var key = Encoding.ASCII.GetBytes(ConfigurationApi.JwtPrivateKey);
            var handler = new JwtSecurityTokenHandler();

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(24),
                Subject = GenerateClaims(data)
            };



            var token = handler.CreateToken(tokenDescriptor);


            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(User user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim("id", user.Id.ToString()));
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            ci.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));

            return ci;
        }
    }
}