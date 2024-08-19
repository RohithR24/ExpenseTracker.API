using Microsoft.VisualBasic;
using DTO;
using DTO.Create;
using Data;
using System.Data;

namespace Controllers
{
    public static  class UserController
    {
       //static List<User> UserData = new List<User>(){new(1, "User1", "Email1", "Passs1", DateAndTime.Now)};        
        public static RouteGroupBuilder AllUserAPIs(this WebApplication webApplication)
        {
            var group = webApplication.MapGroup("user");

                group.MapGet("/", () => "Hello User: ");

                group.MapPost("/", (NewUser newUser, ExpenseTrackerContext dbContext) => {

                    Data.Models.User user = new Data.Models.User(){
                        UserName = newUser.Username,
                        Email = newUser.Email,
                        PasswordHash = newUser.PasswordHash,
                        CreatedAt  = DateTime.Now
                    };

                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();

                    return Results.Ok("Created");
                });

            return group;

        }

    }
}