using MonMart.Models;
using MonMart.DTOs;

namespace MonMart.Services
{
    public interface IUserService
    {
        string? Authenticate(AuthenticationDTO authenticationDTO);
        IEnumerable<UserModel> GetAll();
        UserModel GetByUserId(int id);
    }
}
