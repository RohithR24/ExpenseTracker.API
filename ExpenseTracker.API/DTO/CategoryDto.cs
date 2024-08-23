using DTO;

public class CategoryDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public UserSummary User { get; set; }
    public ICollection<TransactionDto> Transactions { get; set; }
    public ICollection<BudgetDto> Budgets { get; set; }
}