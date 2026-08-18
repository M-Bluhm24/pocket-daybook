namespace MJB.PocketDaybook.BL.Models
{
    /* 
     * AccountCategory defines the normal balance behavior for each account type.
     * The Ledger uses this to determine whether debits or credits increase the account.
     */

    public enum AccountCategory
    {
        Asset,      // Debit increases, Credit decreases
        Expense,    // Debit increases, Credit decreases
        Drawing,    // Debit increases, Credit decreases (contra-equity)
        Capital,    // Credit increases, Debit decreases
        Liability,  // Credit increases, Debit decreases
        Income      // Credit increases, Debit decreases
    }
}
