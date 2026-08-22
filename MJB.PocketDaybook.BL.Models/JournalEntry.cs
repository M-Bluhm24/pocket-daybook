namespace MJB.PocketDaybook.BL.Models
{
    public class JournalEntry
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<JournalLine> Lines { get; set; } = new List<JournalLine>();

        public decimal TotalDebit => Lines.Sum(line => line.Debit);
        public decimal TotalCredit => Lines.Sum(line => line.Credit);
        public bool IsBalanced => TotalDebit == TotalCredit;
    }
}
