using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{

    public class Category
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public User? User { get; set; }
  
    }
}