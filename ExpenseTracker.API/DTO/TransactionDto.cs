using DTO;

public class TransactionDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public UserSummary User { get; set; }
    public CategoryDto Category { get; set; }
}
