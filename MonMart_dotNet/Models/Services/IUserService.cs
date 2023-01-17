using MonMart.Models;

namespace MonMart.Services
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetAll();
        UserModel GetByUserId(int id);
    }
}
