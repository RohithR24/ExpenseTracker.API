using System.ComponentModel.DataAnnotations;

namespace DTO{

    public class Login{
        [Required] [StringLength(100)] public string UserName {get; set;}

        [Required] [StringLength(100)] public string Password {get; set;}
    }
}