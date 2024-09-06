
using System.Diagnostics.Eventing.Reader;
using Data;
using Data.Models;

namespace Repository{
    public class TransactionRepository : ITransactionRepository
    {
        readonly private ExpenseTrackerContext _dbContext;
        public TransactionRepository(ExpenseTrackerContext dbContext){
            _dbContext = dbContext;
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
    }
}