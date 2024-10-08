using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{

    public class  User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}