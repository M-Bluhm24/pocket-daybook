namespace MJB.PocketDaybook.PL.Entities
{
    public class tblJournalEntry : IEntity
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<tblJournalLine> JournalEntryLines { get; set; } = new List<tblJournalLine>();

    }
}
