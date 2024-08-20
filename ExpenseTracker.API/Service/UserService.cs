using Data.Models;
using Data.Repository;
using DTO.Create;
using Mappings;
using Service.Impl;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMappings _userMappings;

        public UserService(IUserRepository userRepository, IUserMappings userMappings)
        {
            _userRepository = userRepository;
            _userMappings = userMappings;
        }

        public bool AddUser(NewUser newUser)
        {
            try{
                User user = _userMappings.ToUserEntity(newUser);

                return _userRepository.AddUser(user);;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}