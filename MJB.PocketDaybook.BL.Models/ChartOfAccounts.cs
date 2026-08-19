namespace MJB.PocketDaybook.BL.Models
{
    public class ChartOfAccounts
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Dictionary<AccountCategory, List<Guid>> AccountsByCategory { get; set; } = new Dictionary<AccountCategory, List<Guid>>();
    }
}
