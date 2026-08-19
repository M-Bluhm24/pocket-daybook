namespace MJB.PocketDaybook.BL.Models
{
    public class Budget
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<BudgetItem> BudgetItems { get; set; } = new List<BudgetItem>();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
