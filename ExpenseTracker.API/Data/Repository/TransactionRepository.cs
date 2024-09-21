using Data; 
using Data.Models; 
using DTO; 

namespace Repository
{
    // Transaction repository class implementing the ITransactionRepository interface
    public class TransactionRepository : ITransactionRepository
    {
        // Dependency injection for the database context
        readonly private ExpenseTrackerContext _dbContext;

        // Dependency injection for the logger service
        readonly private ILogger<TransactionRepository> _logger;

        // Constructor to initialize the database context and logger
        public TransactionRepository(ExpenseTrackerContext dbContext, ILogger<TransactionRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        // Method to add a new transaction to the database
        public bool AddTransaction(Transaction transaction)
        {
            _logger.LogInformation($"Attempting to add a new transaction for user {transaction.UserId}.");
            try
            {
                // Add the transaction entity to the database and save changes
                var result = _dbContext.Transactions.Add(transaction);
                _dbContext.SaveChanges();
                
                _logger.LogInformation($"Transaction added successfully for user {transaction.UserId}.");
                return true; // Return true if the transaction is successfully added
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while adding transaction for user {transaction.UserId}: {ex.Message}", ex);
                return false;
            }
        }

        // Method to mark a transaction as deleted by setting its IsDelete property
        public bool MarkTransactionAsDelete(int transactionId)
        {
            _logger.LogInformation($"Attempting to mark transaction {transactionId} as deleted.");
            try
            {
                // Find the transaction by its ID
                var result = _dbContext.Transactions.FirstOrDefault(record => record.Id == transactionId);
                
                if (result == null)
                {
                    _logger.LogWarning($"Transaction {transactionId} not found.");
                    return false;
                }

                // Set the IsDelete property to 1 (mark as deleted)
                result.IsDelete = 1;
                _dbContext.SaveChanges();
                
                _logger.LogInformation($"Transaction {transactionId} marked as deleted.");
                return true; // Return true if the transaction is marked as deleted
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while marking transaction {transactionId} as deleted: {ex.Message}", ex);
                return false;
            }
        }

        // Method to fetch a transaction by its ID
        public Transaction FetchById(int transactionId)
        {
            _logger.LogInformation($"Fetching transaction {transactionId}.");
            try
            {
                // Find the transaction by its ID and return it
                var result = _dbContext.Transactions.FirstOrDefault(record => record.Id == transactionId);
                
                if (result == null)
                {
                    _logger.LogWarning($"Transaction {transactionId} not found.");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while fetching transaction {transactionId}: {ex.Message}", ex);
            }

            // Return null if no transaction is found or an error occurs
            return null;
        }

        // Method to fetch all transactions for a given user ID
        public List<Transaction> FetchTransactionsById(int userId)
        {
            _logger.LogInformation($"Fetching all transactions for user {userId}.");
            try
            {
                // Find all transactions for the specified user and return them as a list
                var result = _dbContext.Transactions.Where(record => record.UserId == userId).ToList();

                if (result == null || result.Count == 0)
                {
                    _logger.LogWarning($"No transactions found for user {userId}.");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while fetching transactions for user {userId}: {ex.Message}", ex);
            }

            // Return null if no transactions are found or an error occurs
            return null;
        }

        // Method to update an existing transaction by its ID
        public int UpdateTransactionById(UpdateTransaction transaction)
        {
            _logger.LogInformation($"Attempting to update transaction {transaction.Id}.");
            try
            {
                // Find the transaction by its ID
                var result = _dbContext.Transactions.FirstOrDefault(record => record.Id == transaction.Id);
                
                if (result == null)
                {
                    _logger.LogWarning($"Transaction {transaction.Id} not found.");
                    return 0;
                }

                // Update the transaction properties with new values
                result.Amount = transaction.Amount;
                result.Description = transaction.Description;
                result.CategoryId = transaction.CategoryId;
                result.Type = transaction.Type;

                // Save the updated transaction
                _dbContext.SaveChanges();
                _logger.LogInformation($"Transaction {transaction.Id} updated successfully.");
                return 1; // Return 1 if the update was successful
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while updating transaction {transaction.Id}: {ex.Message}", ex);
            }

            // Return 0 if the update fails
            return 0;
        }
    }
}