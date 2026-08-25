namespace MJB.PocketDaybook.PL.Entities
{
    public class tblBudget : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public virtual tblUser User { get; set; }
        public virtual ICollection<tblBudgetItem> BudgetItems { get; set; }
    }
}
