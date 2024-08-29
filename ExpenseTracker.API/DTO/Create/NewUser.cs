using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DTO.Create
{
    public class  NewUser
    {

        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        //public DateTime CreatedAt { get; set; }

    }
}