using Data.Models;
using DTO.Create;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Mappings{
    public class TransactionMapping : ITransactionMapping
    {
        public Transaction ToTransactionEntity(NewTransaction newTransaction)
        {
            return new Transaction(){
                UserId= newTransaction.UserId,
                CategoryId = newTransaction.CategoryId,
                Type = newTransaction.Type,
                Description = newTransaction.Description,
                Amount = newTransaction.Amount,
                Date = DateTime.Now
            };
        }
    }
}