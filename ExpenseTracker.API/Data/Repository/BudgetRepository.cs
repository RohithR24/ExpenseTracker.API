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
    }
}