namespace MJB.PocketDaybook.BL.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }

        // User facing properties
        public Guid SourceAccount { get; set; }
        public Guid DestinationAccount { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public Guid TypeId { get; set; }
        public string Memo { get; set; }
        public Guid CategoryId { get; set; }
        public Guid JournalEntryId { get; set; }

        // Navigation properties
        public Account? SourceAccountRef { get; set; }
        public Account? DestinationAccountRef { get; set; }
        public TransactionCategory? Category { get; set; }
        public JournalEntry? JournalEntry { get; set; }
    }
}
