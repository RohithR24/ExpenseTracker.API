using Data.Models;
using DTO;

namespace  Repository
{
    public interface ITransactionRepository
    {
        public bool AddTransaction(Transaction transaction);

        public int UpdateTransactionById(UpdateTransaction transaction);

        public bool MarkTransactionAsDelete(int transactionId);

        public Transaction FetchById(int transactionId);

        public List<Data.Models.Transaction> FetchTransactionsById(int userId);
    }
}