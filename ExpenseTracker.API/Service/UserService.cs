using Data.Models;
using Data.Repository;
using DTO;
using DTO.Create;
using Mappings;
using Service.Impl;
namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMappings _userMappings;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, 
            IUserMappings userMappings, 
            ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _userMappings = userMappings;
            _logger = logger;
        }

        public bool AddUser(NewUser newUser)
        {
            try{
                User user = _userMappings.ToUserEntity(newUser);

                return _userRepository.AddUser(user);;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the User data.");
                return false;
            }
            
        }

        public List<UserDto> GetAllUsers()
        {
            List<User> users= _userRepository.FetchAllUsers();
            List<UserDto> usersDto = new List<UserDto>();;
            foreach( var user in users){
                usersDto.Add(_userMappings.ToUserDto(user));
            }
            return usersDto;
        }
    }
}