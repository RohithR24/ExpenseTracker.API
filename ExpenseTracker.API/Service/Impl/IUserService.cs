using Data.Models;
using DTO;
using DTO.Create;
namespace Service.Impl{
    public interface IUserService{
        public bool AddUser(NewUser newUser);
        public List<UserDto> GetAllUsers();
        public bool DeleteUserWithId(int id);
        public bool ValidateLogin(Login login);
    }
}