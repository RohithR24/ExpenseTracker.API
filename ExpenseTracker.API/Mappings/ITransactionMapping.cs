using Data.Models;
using DTO.Create;

namespace Mappings{
    public interface ITransactionMapping{
        public Transaction ToTransactionEntity(NewTransaction newTransaction);

        public TransactionDto ToTransactionDTO(Transaction transaction);
    }
}