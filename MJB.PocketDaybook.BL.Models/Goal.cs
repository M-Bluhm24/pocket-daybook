namespace MJB.PocketDaybook.BL.Models
{
    public class Goal
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Account Account { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime TargetDate { get; set; }
        public bool IsCompleted => CurrentAmount >= TargetAmount;
        public decimal Progress => TargetAmount == 0 ? 0 : CurrentAmount / TargetAmount;

    }
}
