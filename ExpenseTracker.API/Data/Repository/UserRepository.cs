using Data;
using Data.Models;
using Data.Repository;

namespace Service
{
    public class UserRepository : IUserRepository
    {

        private readonly ExpenseTrackerContext _dbContext;

        public UserRepository(ExpenseTrackerContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddUser(User user)
        {
            try
            {
                // Add the user to the database context
                _dbContext.Users.Add(user);
                
                // Save changes to the database
                _dbContext.SaveChanges();

                // Return true to indicate success
                return true;
            }
            catch (Exception ex)
            {

                // Return false to indicate failure
                return false;
            }
        }
    }
}