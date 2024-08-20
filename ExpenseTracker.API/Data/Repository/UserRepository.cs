using Data;
using Data.Models;
using Data.Repository;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly ExpenseTrackerContext _dbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ExpenseTrackerContext dbContext,  ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public bool AddUser(User user)
        {
           _logger.LogInformation("Starting AddUser method.");

            try
            {
                _logger.LogInformation("Attempting to add user with Email: {Email}", user.Email);
                
                // Add the user to the database context
                _dbContext.Users.Add(user);

                _logger.LogInformation("User added to the DbContext.");

                // Save changes to the database
                _dbContext.SaveChanges();

                _logger.LogInformation("Changes saved to the database successfully.");
                
                // Return true to indicate success
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving the user with Email: {Email}.", user.Email);
                // Return false to indicate failure
                return false;
            }
            finally
            {
                _logger.LogInformation("Ending AddUser method.");
            }
        }
    }
}