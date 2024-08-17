using Microsoft.VisualBasic;
using Models; 

namespace Controllers
{
    public static  class UserController
    {
       //static List<User> UserData = new List<User>(){new(1, "User1", "Email1", "Passs1", DateAndTime.Now)};        
        public static RouteGroupBuilder AllUserAPIs(this WebApplication webApplication)
        {
            var group = webApplication.MapGroup("User");

                group.MapGet("/", () => "Hello User: ");

            return group;

        }

    }
}