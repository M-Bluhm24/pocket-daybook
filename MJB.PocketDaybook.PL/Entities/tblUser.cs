namespace MJB.PocketDaybook.PL.Entities
{
    public class tblUser : IEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual ICollection<tblGoal> Goals { get; set; } = new List<tblGoal>();
        public virtual ICollection<tblBudget> Budgets { get; set; } = new List<tblBudget>();
        public virtual ICollection<tblAccount> Accounts { get; set; } = new List<tblAccount>();
        public virtual ICollection<tblMerchant> Merchants { get; set; } = new List<tblMerchant>();
        public virtual ICollection<tblTransactionCategory> TransactionCategories { get; set; } = new List<tblTransactionCategory>();
    }
}
