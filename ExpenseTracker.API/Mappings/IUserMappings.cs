using Data.Models;
using DTO.Create;

namespace Mappings{
    public interface IUserMappings
    {
        public User ToUserEntity(NewUser newUser);
    }
}