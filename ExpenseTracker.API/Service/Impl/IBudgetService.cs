using Data.Models;
using DTO.Create;

namespace Service.Impl
{
    public interface IBudgetService
    {
        public bool SetBudget(NewBudget newBudget);
    }
}
