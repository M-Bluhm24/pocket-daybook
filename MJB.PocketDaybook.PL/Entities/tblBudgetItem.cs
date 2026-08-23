namespace MJB.PocketDaybook.PL.Entities
{
    public class tblBudgetItem : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AccountId { get; set; }
        public Guid BudgetId { get; set; }  
        public decimal Amount { get; set; }

    }
}
