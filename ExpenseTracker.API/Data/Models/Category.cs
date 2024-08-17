namespace Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public User User { get; set; }
    }
}