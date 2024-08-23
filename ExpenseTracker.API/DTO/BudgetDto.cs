using DTO;

public class BudgetDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public decimal Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public UserSummary User { get; set; }
    public CategoryDto Category { get; set; }
}
