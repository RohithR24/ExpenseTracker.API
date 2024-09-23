using Data;
using Data.Models;
using Microsoft.Extensions.Logging;

namespace Repository
{
    public class BudgetRepository : IBudgetRepository
    {
        public readonly ExpenseTrackerContext _dbContext;
        private readonly ILogger<BudgetRepository> _logger; // Injecting logger for logging

        public BudgetRepository(ExpenseTrackerContext dbContext, ILogger<BudgetRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public bool AddBudget(Budget budget)
        {
            try
            {
                _logger.LogInformation("Attempting to add a new budget for user {UserId} and category {CategoryId}", budget.UserId, budget.CategoryId);
                
                var result = _dbContext.Budgets.Add(budget);
                _dbContext.SaveChanges();

                _logger.LogInformation("Successfully added a new budget with Id {BudgetId}", budget.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a new budget for user {UserId} and category {CategoryId}", budget.UserId, budget.CategoryId);
                return false;
            }
        }

        public Budget FetchTotalBudget(int userId, int categoryId, DateTime transactionDate)
        {
            _logger.LogInformation("Fetching total budget for user {UserId}, category {CategoryId} on {TransactionDate}", userId, categoryId, transactionDate);

            try
            {
                var budget = _dbContext.Budgets
                    .Where(b => b.UserId == userId
                                && b.CategoryId == categoryId
                                && b.StartDate <= transactionDate
                                && b.EndDate >= transactionDate)
                    .FirstOrDefault();

                if (budget != null)
                {
                    _logger.LogInformation("Successfully fetched budget with Id {BudgetId}", budget.Id);
                }
                else
                {
                    _logger.LogWarning("No budget found for user {UserId} and category {CategoryId} within the date {TransactionDate}", userId, categoryId, transactionDate);
                }

                return budget;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching total budget for user {UserId} and category {CategoryId} on {TransactionDate}", userId, categoryId, transactionDate);
                return null;
            }
        }

        public bool UpdateBudgetAmount(int budgetId, decimal newAmount)
        {
            _logger.LogInformation("Attempting to update the amount of budget with Id {BudgetId} to {NewAmount}", budgetId, newAmount);

            try
            {
                // Retrieve the budget from the database using the provided budgetId
                var budget = _dbContext.Budgets.FirstOrDefault(b => b.Id == budgetId);

                // Check if the budget was found
                if (budget != null)
                {
                    // Update the amount of the budget
                    budget.Amount = (int)newAmount;

                    // Save the changes to the database
                    _dbContext.SaveChanges();
                    _logger.LogInformation("Successfully updated the budget amount for budget with Id {BudgetId}", budgetId);
                }
                else
                {
                    _logger.LogWarning("No budget found with Id {BudgetId} to update the amount", budgetId);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating the budget amount for budget with Id {BudgetId}", budgetId);
                return false;
            }
        }
    }
}
