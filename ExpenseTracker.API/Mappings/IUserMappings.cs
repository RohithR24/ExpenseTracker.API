using Data.Models;
using DTO;
using DTO.Create;

namespace Mappings{
    public interface IUserMappings
    {
        public Data.Models.User ToUserEntity(NewUser newUser);

        public UserDto ToUserDto(User user);
    }
}