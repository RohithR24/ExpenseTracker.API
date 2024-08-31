using Data.Models;
using DTO.Create;

namespace Mappings{
    public class BudgetMapping : IBudgetMapping
    {
        public Budget ToBudgetEntity(NewBudget newBudget)
        {
            return new Budget(){
                UserId = newBudget.UserId,
                CategoryId = newBudget.CategoryId,
                Amount = newBudget.Amount,
                StartDate = newBudget.StartDate,
                EndDate = newBudget.EndDate
            };
        }
    }
}