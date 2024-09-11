using Data.Models;
using DTO.Create;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Mappings{
    public class TransactionMapping : ITransactionMapping
    {
        public Transaction ToTransactionEntity(NewTransaction transaction)
        {
            return new Transaction(){
                UserId= transaction.UserId,
                CategoryId = transaction.CategoryId,
                Type = transaction.Type,
                Description = transaction.Description,
                Amount = transaction.Amount,
                Date = DateTime.Now
            };
        }


        public TransactionDto ToTransactionDTO(Transaction transaction)
        {
            return new TransactionDto(){
                Id= transaction.Id,
                CategoryId = transaction.CategoryId,
                Amount = transaction.Amount,
                Description = transaction.Description,
                Date = transaction.Date,
                Type = transaction.Type,
            };
        }
    }
}