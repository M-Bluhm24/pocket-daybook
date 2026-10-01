namespace MJB.PocketDaybook.PL.Entities
{
    public class tblTransactionCategory : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public virtual tblUser User { get; set; }
    }
}
