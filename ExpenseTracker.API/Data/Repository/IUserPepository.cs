using Data.Models;

namespace Data.Repository{
    public interface IUserRepository
    {
        bool AddUser(User user);

        List<User> FetchAllUsers();
    }
}