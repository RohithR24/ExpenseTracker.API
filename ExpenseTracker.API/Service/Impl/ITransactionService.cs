using System.Transactions;
using DTO.Create;

namespace Service.Impl{
    public interface ITransactionService{
        public bool AddTransaction(NewTransaction createTransaction, out string Message);
        public bool DeleteTransaction(int transactionId);

        public List<Transaction> TransactionsByUserId(int userId);
    }
}