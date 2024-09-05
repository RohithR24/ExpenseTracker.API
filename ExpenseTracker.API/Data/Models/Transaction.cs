using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int IsDelete {get; set;} = 1;
        public User User { get; set; }
        public Category Category { get; set; }
    }
}