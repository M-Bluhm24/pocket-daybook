namespace MJB.PocketDaybook.PL.Entities
{
    public class tblGoal : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; } 
        public Guid AccountId { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime TargetDate { get; set; }

        public virtual tblAccount Account { get; set; }
        public virtual tblUser User { get; set; }
    }
}
