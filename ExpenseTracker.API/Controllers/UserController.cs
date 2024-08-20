using DTO.Create;
using Data;
using Data.Models;
using Service.Impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ExpenseTrackerContext _dbContext;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ExpenseTrackerContext dbContext, ILogger<UserController> logger)
        {
            _userService = userService;
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet("")]
        public IResult GetAllUsers()
        {
            _logger.LogInformation("Starting GetAllUsers method.");

            try
            {
                var users = _userService.GetAllUsers();

                _logger.LogInformation("Fetched {Count} users from the database.", users.Count());

                return Results.Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all users.");
                return Results.StatusCode(500); // Internal Server Error
            }
            finally
            {
                _logger.LogInformation("Ending GetAllUsers method.");
            }
        }

        [HttpPost("")]
        public IResult AddNewUser([FromBody] NewUser newUser)
        {
            _logger.LogInformation("Starting AddNewUser method with Email: {Email}", newUser.Email);

            try
            {
                var result = _userService.AddUser(newUser);

                if (result)
                {
                    _logger.LogInformation("User with Email: {Email} added successfully.", newUser.Email);
                    return Results.Created();
                }
                else
                {
                    _logger.LogWarning("Failed to add user with Email: {Email}.", newUser.Email);
                    return Results.BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the user with Email: {Email}.", newUser.Email);
                return Results.StatusCode(500); // Internal Server Error
            }
            finally
            {
                _logger.LogInformation("Ending AddNewUser method.");
            }
        }
    }
}
