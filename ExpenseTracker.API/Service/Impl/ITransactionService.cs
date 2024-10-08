using Data.Models;
using DTO;
using DTO.Create;

namespace Service.Impl{
    public interface ITransactionService{
        public bool AddTransaction(NewTransaction createTransaction, out string Message);
        public bool DeleteTransaction(int transactionId);
        public List<TransactionDto> TransactionsByUserId(int userId);
         public bool UpdateTransaction(UpdateTransaction updateTransaction);
    }
}