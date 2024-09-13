
using System.Diagnostics.Eventing.Reader;
using Data;
using Data.Models;

namespace Repository{
    public class TransactionRepository : ITransactionRepository
    {
        readonly private ExpenseTrackerContext _dbContext;

        readonly private ILogger<TransactionRepository> _logger;
        public TransactionRepository(ExpenseTrackerContext dbContext, ILogger<TransactionRepository> logger){
            _dbContext = dbContext;
            _logger = logger;
        }
        public bool AddTransaction(Transaction transaction)
        {
            try{
                var result  = _dbContext.Transactions.Add(transaction);
                _dbContext.SaveChanges();
                
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool MarkTransactionAsDelete(int transactionId)
        {
            try{
                var result  = _dbContext.Transactions.FirstOrDefault(record => record.Id == transactionId);
                result.IsDelete = 1;
                _dbContext.SaveChanges();
                
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Transaction FetchById(int transactionId)
        {
            try{
                var result  = _dbContext.Transactions.FirstOrDefault(record => record.Id == transactionId);
                
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception while fetching transaction by transactionId: {transactionId}");
            }

            return null;
        }

        public List<Transaction> FetchTransactionsById(int userId)
        {   

            try{
                var result  = _dbContext.Transactions.Where(record => record.UserId == userId).ToList();
                
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception while fetching transactions by userId: {userId}");
            }

            return null;
        }

        public int UpdateTransaction(Transaction transaction)
        {
            try{
                var result  = _dbContext.Transactions.FirstOrDefault(record => record.Id == transaction.Id);
                result.Amount = transaction.Amount;
                result.Description = transaction.Description;
                result.CategoryId = transaction.CategoryId;
                result.Type = transaction.Type;
                result.Date = transaction.Date;

                _dbContext.SaveChanges();
                return 1;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception while Updating the transaction");
            }

            return 0;
        }
    }
}