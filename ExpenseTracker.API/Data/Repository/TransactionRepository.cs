
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
                _logger.LogError($"Exception while fetching transaction with Id: {transactionId}");
            }

            return null;
        }
    }
}