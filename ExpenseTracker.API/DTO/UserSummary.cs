using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DTO
{
    public record class  UserSummary
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<CategoryDto> Categories { get; set; }
        public ICollection<TransactionDto> Transactions { get; set; }
        public ICollection<BudgetDto> Budgets { get; set; }
    }

    
}