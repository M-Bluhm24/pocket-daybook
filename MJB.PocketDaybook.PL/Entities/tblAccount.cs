namespace MJB.PocketDaybook.PL.Entities
{
    public class tblAccount : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal StartingBalance { get; set; }
        public decimal CurrentBalance { get; set; }
        public Guid CategoryId { get; set; }
    }
}
