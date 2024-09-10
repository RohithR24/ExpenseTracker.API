using DTO.Create;
using Microsoft.AspNetCore.Mvc;
using Service.Impl;

namespace Controller{

    [Route("api/[controller]")]
    public class TransactionController: ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService _transactionService;

        public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }
        

        [HttpGet("{userId}")]
        public IResult AllTransactionsOfUser(int userId){
            return Results.Ok();
        }
        [HttpPost("")]
        public IResult AddNewUser([FromBody] NewTransaction newTransaction)
        {
            _logger.LogInformation("Starting AddNewUser method with UserId ", newTransaction.UserId);
            try
            {
                string message;
                var result = _transactionService.AddTransaction(newTransaction, out message);

                if (result)
                {
                    _logger.LogInformation("User with UserId: {UserId} added successfully.", newTransaction.UserId);
                    return Results.Created();
                }
                else
                {
                    _logger.LogWarning("Failed to add Transaction with UserId:", newTransaction.UserId);
                    return Results.BadRequest(message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the Transaction with UserId:", newTransaction.UserId);
                return Results.StatusCode(500); // Internal Server Error
            }
            finally
            {
                _logger.LogInformation("Ending AddTransaction method.");
            }
        }

        [HttpDelete("{transactionId}")]

        public IResult DeleteTransaction(int transactionId){
            _logger.LogInformation("Starting Delete Transaction method with transactionId ", transactionId);
            try
            {
                var result = _transactionService.DeleteTransaction(transactionId);

                if (result)
                {
                    _logger.LogInformation($"Transaction with Id: {transactionId} deleted successfully.", transactionId);
                    return Results.Ok();
                }
                else
                {
                    _logger.LogWarning($"Failed to delete Transaction with Id: {transactionId}");
                    return Results.BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the Transaction with {transactionId}:");
                return Results.StatusCode(500); // Internal Server Error
            }
            finally
            {
                _logger.LogInformation("Ending Delete Transaction method.");
            }
             
        }

    }
}