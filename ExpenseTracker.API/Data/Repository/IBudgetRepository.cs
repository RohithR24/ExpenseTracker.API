using Data.Models;

namespace Repository{
    public interface IBudgetRepository{
        public bool AddBudget(Budget budget);
    }
}
