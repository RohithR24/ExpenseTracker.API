using Data.Models;
using DTO.Create;

namespace Mappings{
    public interface IBudgetMapping{
        public Budget ToBudgetEntity(NewBudget newBudget);
    }
}