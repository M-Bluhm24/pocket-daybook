namespace MJB.PocketDaybook.BL.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public AccountCategory Category { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal StartingBalance { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
