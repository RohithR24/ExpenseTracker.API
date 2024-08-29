using System.Transactions;

namespace  Repository
{
    public interface ITransactionRepository
    {
        public bool AddTransaction(Transaction transaction);
    }
}