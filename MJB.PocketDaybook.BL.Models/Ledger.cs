namespace MJB.PocketDaybook.BL.Models
{
    public class Ledger
    {
        public List<Account> Accounts { get; set; } = new List<Account>();
        public List<JournalEntry> JournalEntries { get; set; } = new List<JournalEntry>();
    }
}
