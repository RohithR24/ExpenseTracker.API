//NewTransaction

using DTO;

namespace DTO.Create
{
    public class NewTransaction
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}

