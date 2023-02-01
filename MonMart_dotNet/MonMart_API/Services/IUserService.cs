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
    public interface IUserService
    {
        UserDTO Authenticate(AuthenticationDTO authenticationDTO);
        IEnumerable<UserModel> GetAll();
        UserModel GetByUserId(int id);
    }
}
