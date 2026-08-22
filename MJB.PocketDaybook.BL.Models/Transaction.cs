namespace MJB.PocketDaybook.BL.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Account SourceAccount { get; set; }
        public Account DestinationAccount { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
        public string Memo { get; set; }
        public TransactionCategory Category { get; set; }

    }
}
