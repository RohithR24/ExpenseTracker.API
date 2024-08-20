using DTO.Create;
using Data;
using Data.Models;
using Service.Impl;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {

        
        private readonly IUserService _userService;
        private readonly ExpenseTrackerContext _dbContext;

        public UserController(IUserService userService, ExpenseTrackerContext dbContext){
            _userService = userService;
            _dbContext = dbContext;
        }

        [HttpGet("")]
        public IResult GetAllUsers()
        {
            var users = _dbContext.Users.AsParallel<User>();
            return Results.Ok(users);
        }


        [HttpPost("")]
        public IResult AddNewUser([FromBody] NewUser newUser)
        {
            
            var result = _userService.AddUser(newUser);

            return result ? Results.Created(): Results.BadRequest();
        }

    }
}