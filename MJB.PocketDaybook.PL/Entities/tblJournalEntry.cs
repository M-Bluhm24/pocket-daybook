namespace MJB.PocketDaybook.PL.Entities
{
    public class tblJournalEntry : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? MerchantId { get; set; }
        public DateTime EntryDate { get; set; }
        public string Memo { get; set; } = string.Empty;

        public virtual ICollection<tblJournalLine> JournalEntryLines { get; set; } = new List<tblJournalLine>();
        public virtual tblUser User { get; set; } 
        public virtual tblMerchant Merchant { get; set; }   

    }
}
