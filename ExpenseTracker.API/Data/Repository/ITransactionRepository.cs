using Data.Models;

namespace  Repository
{
    public interface ITransactionRepository
    {
        public bool AddTransaction(Transaction transaction);
    }
}