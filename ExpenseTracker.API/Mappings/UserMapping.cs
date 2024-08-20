using Data.Models;
using DTO;
using DTO.Create;

namespace Mappings{
    public class UserMappings : IUserMappings
    {

        public User ToUserEntity(NewUser newUser)
        {
            User user = new User(){
                UserName = newUser.Username,
                Email = newUser.Email,
                PasswordHash = newUser.PasswordHash,
                CreatedAt  = DateTime.Now
            };
            
            return user;
        }

        public UserDto ToUserDto(User user)
        {
            UserDto userDto = new UserDto(){
                Id = user.Id,
                Email = user.Email,
                Username = user.UserName,
            };
            
            return userDto;
        }

    }
}