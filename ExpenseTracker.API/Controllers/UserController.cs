using DTO.Create;
using Data;
using Data.Models;
using Service.Impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DTO;

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


        [HttpPost("/login")]
        public IResult LogIn([FromBody] Login login)
        {
            _logger.LogInformation("Starting Login method with UserName: {UserName}", login.UserName);

            try
            {
                var result = _userService.ValidateLogin(login);

                if (result)
                {
                    _logger.LogInformation("Validated successfully", login.UserName);
                    return Results.Ok();
                }
                else
                {
                    _logger.LogWarning("Failed to Validated.", login.UserName);
                    return Results.BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error Login.", login.UserName);
                return Results.StatusCode(500); // Internal Server Error
            }
            finally
            {
                _logger.LogInformation("Ending Validation method.");
            }
        }

        [HttpDelete("/{id}")]
        public IResult DeleteUser(int id)
        {
            _logger.LogInformation("Starting DeleteUser method with Email: {Email}", id);

            try
            {
                var result = _userService.DeleteUserWithId(id);

                if (result)
                    return Results.NoContent();
                else
                    return Results.BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while Delete User with .",  id);
                return Results.StatusCode(500); // Internal Server Error
            }
            finally
            {
                _logger.LogInformation("Ending DeleteUser method.");
            }
        }
    }
}
