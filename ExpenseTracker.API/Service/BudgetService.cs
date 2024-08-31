using DTO.Create;
using Mappings;
using Repository;
using Service.Impl;

namespace Service;
public class BudgetService : IBudgetService
{
    private readonly IBudgetRepository _budgetRepository;

    private readonly IBudgetMapping _budgetMapping;
    public BudgetService(IBudgetRepository budgetRepository,IBudgetMapping budgetMapping)
    {
        _budgetRepository = budgetRepository;
        _budgetMapping = budgetMapping;
    }
    public bool SetBudget(NewBudget newBudget)
    {
        return _budgetRepository.AddBudget(_budgetMapping.ToBudgetEntity(newBudget));
    }
}