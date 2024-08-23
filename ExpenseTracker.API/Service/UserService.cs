using Data.Models;
using Data.Repository;
using DTO;
using DTO.Create;
using Helper;
using Mappings;
using Service.Impl;
namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMappings _userMappings;
        private readonly IPasswordHandler _passwordHandler;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, 
            IUserMappings userMappings, 
            ILogger<UserService> logger,
            IPasswordHandler passwordHandler)
        {
            _userRepository = userRepository;
            _userMappings = userMappings;
            _logger = logger;
            _passwordHandler = passwordHandler;
        }

        public bool AddUser(NewUser newUser)
        {
            try{
                User user = _userMappings.ToUserEntity(newUser);
                user.PasswordHash = _passwordHandler.HashPassword(user.PasswordHash);
                return _userRepository.AddUser(user);;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the User data.");
                return false;
            }
            
        }

        public bool DeleteUserWithId(int id)
        {
            int result = _userRepository.DeleteUser(id);
            return (result>0)? true: false;

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


        public bool ValidateLogin(Login login)
        {
            var passwordHash  = _userRepository.GetPasswordForUserId(login.UserName);

            if(_passwordHandler.VerifyPassword(login.Password, passwordHash))
            {
                return true;
            }
            else{
                return false;
            }
        }
    }
}