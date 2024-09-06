using Data.Models;

namespace  Repository
{
    public interface ITransactionRepository
    {
        public bool AddTransaction(Transaction transaction);

        public bool MarkTransactionAsDelete(int transactionId);

        public Transaction FetchById(int transactionId);
    }
}