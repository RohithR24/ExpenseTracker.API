using Data.Models;
using DTO.Create;
namespace Service.Impl{
    public interface IUserService{
        public bool AddUser(NewUser newUser);
    }
}