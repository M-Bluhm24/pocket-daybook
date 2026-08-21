namespace MJB.PocketDaybook.BL.Models
{
    public class TransactionCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
