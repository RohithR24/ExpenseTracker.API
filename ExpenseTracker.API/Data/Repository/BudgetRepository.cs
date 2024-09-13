using Data;
using Data.Models;

namespace Repository{
    public class BudgetRepository : IBudgetRepository
    {
        public readonly ExpenseTrackerContext _dbContext;
        public BudgetRepository(ExpenseTrackerContext dbContext){
            _dbContext = dbContext;
        }
        public bool AddBudget(Budget budget)
        {
            try{
                var result = _dbContext.Budgets.Add(budget);
                _dbContext.SaveChanges();

                return true;
            }
            catch(Exception ex){
                return false;
            }
        }

        public Budget FetchTotalBudget(int userId, int categoryId, DateTime transactionDate)
        {
            // Sum of the budget amounts that fall within the start and end date
            var budget = _dbContext.Budgets
            .Where(b => b.UserId == userId 
                        && b.CategoryId == categoryId 
                        && b.StartDate <= transactionDate 
                        && b.EndDate >= transactionDate).FirstOrDefault();
            return budget;
        }

        public bool UpdateBudgetAmount(int budgetId, decimal newAmount)
        {
            try{
               // Retrieve the budget from the database using the provided budgetId
                    var budget = _dbContext.Budgets.FirstOrDefault(b => b.Id == budgetId);

                    // Check if the budget was found
                    if (budget != null)
                    {
                        // Update the amount of the budget
                        budget.Amount = (int)newAmount;

                        // Save the changes to the database
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        // Handle the case where the budget with the given ID does not exist
                        
                    }

               return true;
            }
            catch(Exception ex){
                return false;
            }
        }
    }
}