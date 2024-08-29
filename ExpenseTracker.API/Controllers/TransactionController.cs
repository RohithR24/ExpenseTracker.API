using DTO.Create;
using Microsoft.AspNetCore.Mvc;

namespace Controller{

    [Route("api/[controller]")]
    public class TransactionController: ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost("")]
        public IResult AddNewUser([FromBody] NewTransaction newTransaction)
        {
            _logger.LogInformation("Starting AddNewUser method with Email: {Email}", newTransaction.UserId);

            try
            {
                var result = _userService.AddTransaction(newTransaction.UserId);

                if (result)
                {
                    _logger.LogInformation("User with Email: {Email} added successfully.", newTransaction.UserId);
                    return Results.Created();
                }
                else
                {
                    _logger.LogWarning("Failed to add user with Email: {Email}.", newTransaction.UserId);
                    return Results.BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the user with Email: {Email}.", newTransaction.UserId);
                return Results.StatusCode(500); // Internal Server Error
            }
            finally
            {
                _logger.LogInformation("Ending AddNewUser method.");
            }
        }

    }
}