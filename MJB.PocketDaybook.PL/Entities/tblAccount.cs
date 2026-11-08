namespace MJB.PocketDaybook.PL.Entities
{
    public enum AccountCategory
    {
        Asset = 1,
        Liability = 2,
        Equity = 3,
        Income = 4,
        Expense = 5
    }

    public enum NormalBalance
    {
        Debit = 1,
        Credit = 2
    }   

    public class tblAccount : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal StartingBalance { get; set; }
        public decimal CurrentBalance { get; set; }
        public AccountCategory AccountCategory { get; set; }
        public NormalBalance NormalBalance { get; set; }    

        public virtual ICollection<tblBudgetItem> BudgetItems { get; set; } = new List<tblBudgetItem>();
       
        public virtual tblUser User { get; set; }

    }
}
