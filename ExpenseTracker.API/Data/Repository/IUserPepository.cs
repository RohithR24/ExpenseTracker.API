using Data.Models;

namespace Data.Repository{
    public interface IUserRepository
    {
        bool AddUser(User user);

        List<User> FetchAllUsers();

        int DeleteUser(int id);

        string GetPasswordForUserId(string useName);
    }
}