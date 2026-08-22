namespace MJB.PocketDaybook.BL.Models
{
    public class BudgetItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Account Account { get; set; }
        public decimal Amount { get; set; }

    }
}
