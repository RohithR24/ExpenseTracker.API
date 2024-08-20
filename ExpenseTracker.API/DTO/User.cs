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
        public ICollection<Category> Categories { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Budget> Budgets { get; set; }
    }

    
}