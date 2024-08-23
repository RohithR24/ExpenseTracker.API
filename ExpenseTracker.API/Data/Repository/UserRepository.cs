using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpenseTrackerContext _dbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ExpenseTrackerContext dbContext, ILogger<UserRepository> logger)
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
                // Log error with exception details
                _logger.LogError(ex, "An error occurred while saving the user with Email: {Email}.", user.Email);
                // Return false to indicate failure
                return false;
            }
            finally
            {
                _logger.LogInformation("Ending AddUser method.");
            }
        }

        public int DeleteUser(int id)
        {
            _logger.LogInformation("Starting DeleteUser method for User ID: {Id}", id);

            try
            {
                // Find the user by ID
                var user = _dbContext.Users.Find(id);
                if (user == null)
                {
                    _logger.LogWarning("User with ID: {Id} not found.", id);
                    return 0; // Return 0 to indicate no user found
                }

                _logger.LogInformation("User with ID: {Id} found, attempting to delete.", id);
                
                // Attempt to delete the user
                var result = _dbContext.Users.Where(u => u.Id == id).ExecuteDelete();

                _logger.LogInformation("User with ID: {Id} deleted successfully.", id);
                return result; // Return the number of records affected
            }
            catch (Exception ex)
            {
                // Log error with exception details
                _logger.LogError(ex, "An error occurred while deleting the user with ID: {Id}.", id);
                // Return -1 to indicate an error
                return -1;
            }
            finally
            {
                _logger.LogInformation("Ending DeleteUser method for User ID: {Id}", id);
            }
        }

        public List<User> FetchAllUsers()
        {
            _logger.LogInformation("Starting FetchAllUsers method.");

            try
            {
                // Fetch all users from the database in parallel
                var users = _dbContext.Users.AsParallel<User>().ToList();

                _logger.LogInformation("Successfully fetched all users.");
                return users;
            }
            catch (Exception ex)
            {
                // Log error with exception details
                _logger.LogError(ex, "An error occurred while fetching all users.");
                // Return an empty list to indicate an error occurred
                return new List<User>();
            }
            finally
            {
                _logger.LogInformation("Ending FetchAllUsers method.");
            }
        }

        public string GetPasswordForUserId(string userName)
        {
            _logger.LogInformation("Starting GetPasswordForUserId method for Username: {UserName}", userName);

            try
            {
                // Find the user by username
                var user = _dbContext.Users.FirstOrDefault(u => u.UserName == userName);

                if (user == null)
                {
                    _logger.LogWarning("User with Username: {UserName} not found.", userName);
                    return null; // Return null if user not found
                }

                _logger.LogInformation("User with Username: {UserName} found, returning password hash.", userName);
                return user.PasswordHash; // Return the password hash
            }
            catch (Exception ex)
            {
                // Log error with exception details
                _logger.LogError(ex, "An error occurred while getting the password for Username: {UserName}.", userName);
                // Return null to indicate an error
                return null;
            }
            finally
            {
                _logger.LogInformation("Ending GetPasswordForUserId method for Username: {UserName}", userName);
            }
        }
    }
}
