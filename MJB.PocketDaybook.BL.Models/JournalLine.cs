namespace MJB.PocketDaybook.BL.Models
{
    public class JournalLine
    {
        public Guid Id { get; set; }
        public Account Account { get; set; } 
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}
