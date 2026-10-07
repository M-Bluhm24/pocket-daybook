namespace MJB.PocketDaybook.PL.Entities
{
    public enum TransactionType
    {
        Expense,          // Debit Expense, Credit Asset
        Income,           // Debit Asset, Credit Income
        Transfer,         // Debit destination account, Credit source account
        LiabilityPayment, // Debit Liability, Credit Asset
        InvestmentBuy,    // Debit Investment (Asset), Credit Asset (Cash)
        InvestmentSell,   // Debit Asset (Cash), Credit Investment (Asset)
        Drawing,          // Debit Drawing, Credit Asset 
        Interest,         // Debit Asset (Cash), Credit Income (Interest Revenue)
        Capital,          // Debit Asset (Cash), Credit Capital 
        Refund,           // Debit Asset (Cash), Credit Expense (Refund)
        Fee,              // Debit Expense (Fee), Credit Asset (Cash)
        Tax               // Debit Expense (Tax), Credit Asset (Cash)        
    }
    public class tblTransaction : IEntity
    {
        public Guid Id { get; set; }
        public Guid SourceAccountId { get; set; }
        public Guid DestinationAccountId { get; set; }
        public Guid TransactionCategoryId { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType Type { get; set; }
        public string Memo { get; set; }
        public virtual tblUser User { get; set; }
        public virtual tblTransactionCategory TransactionCategory { get; set; }
        public virtual tblAccount SourceAccount { get; set; }
        public virtual tblAccount DestinationAccount { get; set; }
    }
}
