namespace MJB.PocketDaybook.PL.Entities
{
    public class tblTransaction : IEntity
    {
        public Guid Id { get; set; }
        public Guid SourceAccountId { get; set; }
        public Guid DestinationAccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Memo { get; set; }
        public string Category { get; set; }
    }
}
