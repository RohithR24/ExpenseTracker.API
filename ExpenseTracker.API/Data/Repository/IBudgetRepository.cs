using Data.Models;

namespace Repository{
    public interface IBudgetRepository{
        public bool AddBudget(Budget budget);
        public Budget FetchTotalBudget(int userId, int categoryId, DateTime transactionDate);
        public bool UpdateBudgetAmount(int budgetId, decimal newAmount);
    }
}
