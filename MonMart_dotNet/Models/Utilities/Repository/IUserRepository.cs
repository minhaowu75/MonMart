using MonMart.Models;

namespace MonMart.Utilities.Repository
{
    public interface IUserRepository
    {
        UserModel GetById(int id);

        IEnumerable<UserModel> GetAll();
    }
}
