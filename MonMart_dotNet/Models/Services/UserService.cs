using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MonMart.Utilities;
using MonMart.Models;
using MonMart.DTOs;
using System.Text;

namespace MonMart.Services
{
    public class UserService : IUserService
    {
        // Placeholder for a db.
        private List<UserModel> _users = new List<UserModel>
        {
            new UserModel { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        };
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string? Authenticate(AuthenticationDTO authenticationDTO)
        {
            var user = _users.SingleOrDefault(x => x.Username == authenticationDTO.UserName && x.Password == authenticationDTO.Password);

            if (user == null)
            {
                return null;
            }

            var token = GenerateJWTToken(user);

            return token;
        }

        private string GenerateJWTToken(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
