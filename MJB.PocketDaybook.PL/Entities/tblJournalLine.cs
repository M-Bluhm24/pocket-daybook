namespace MJB.PocketDaybook.PL.Entities
{
    public class tblJournalLine : IEntity
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid JournalEntryId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}
