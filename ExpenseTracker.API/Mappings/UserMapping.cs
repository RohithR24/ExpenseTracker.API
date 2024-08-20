using Data.Models;
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
    }
}