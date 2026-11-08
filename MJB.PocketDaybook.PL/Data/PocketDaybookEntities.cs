using MJB.PocketDaybook.PL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel;

namespace MJB.PocketDaybook.PL.Data
{
    public class PocketDaybookEntities : DbContext
    {
        Guid[] userId = new Guid[2];
        Guid[] currencyId = new Guid[2];
        Guid[] merchantId = new Guid[8];
        Guid[] accountId = new Guid[40];
        Guid[] itemId = new Guid[10];
        Guid[] itemPriceId = new Guid[2];
        Guid[] transactionCategoryId = new Guid[9];
        Guid[] transactionId = new Guid[10];
        Guid[] budgetId = new Guid[3];
        Guid[] budgetItemId = new Guid[6];
        Guid[] goalId = new Guid[3];
        Guid[] journalEntryId = new Guid[10];
        Guid[] journalLineId = new Guid[20];
        Guid[] currencyExchangeId = new Guid[3];

        /**
         * Table Creations
         */
        public virtual DbSet<tblBudget> tblBudgets { get; set; }


        public PocketDaybookEntities(DbContextOptions<PocketDaybookEntities> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public PocketDaybookEntities()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            CreateUser(modelBuilder);
            CreateCurrency(modelBuilder);
            CreateMerchant(modelBuilder);
            CreateAccount(modelBuilder);
            CreateItem(modelBuilder);    
            CreateTransactionCategory(modelBuilder);
            CreateTransaction(modelBuilder);
            CreateItemPrice(modelBuilder);
            CreateBudget(modelBuilder);
            CreateBudgetItem(modelBuilder);
            CreateGoal(modelBuilder);
            CreateJournalEntry(modelBuilder);
            CreateJournalLine(modelBuilder);
            CreateCurrencyExchange(modelBuilder);
        }

        private void CreateUser(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < userId.Length; i++)
            {
                userId[i] = Guid.NewGuid();
            }

            modelBuilder.Entity<tblUser>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(50);
                entity.HasMany(e => e.Goals)
                      .WithOne(g => g.User)
                      .HasForeignKey(g => g.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(e => e.Budgets)
                      .WithOne(b => b.User)
                      .HasForeignKey(b => b.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(e => e.Accounts)
                      .WithOne(a => a.User)
                      .HasForeignKey(a => a.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            List<tblUser> users = new List<tblUser>
            {
                new tblUser { Id = userId[0], UserName = "SpongeBob", Password = GetHash("gary") },
                new tblUser { Id = userId[1], UserName = "Squidward", Password = GetHash("clarinet") }
            };

            modelBuilder.Entity<tblUser>().HasData(users);
        }

        private void CreateCurrency(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < currencyId.Length; i++)
            {
                currencyId[i] = Guid.NewGuid();
            }

            modelBuilder.Entity<tblCurrency>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblCurrency");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Code).IsRequired().HasMaxLength(3);
                entity.Property(e => e.Symbol).IsRequired().HasMaxLength(5);
                entity.Property(e => e.DecimalPlaces).IsRequired();
            });

            List<tblCurrency> currencies = new List<tblCurrency>
            {
                new tblCurrency { Id = currencyId[0], Name = "US Dollar", Code = "USD", Symbol = "$", DecimalPlaces = 2 },
                new tblCurrency { Id = currencyId[1], Name = "Euro", Code = "EUR", Symbol = "€", DecimalPlaces = 2 }
            };

            modelBuilder.Entity<tblCurrency>().HasData(currencies);
        }

        private void CreateMerchant(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < merchantId.Length; i++)
            {
                merchantId[i] = Guid.NewGuid();
            }

            modelBuilder.Entity<tblMerchant>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblMerchant");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Website).HasMaxLength(200);
                entity.HasMany(e => e.ItemPrices)
                      .WithOne(ip => ip.Merchant)
                      .HasForeignKey(ip => ip.MerchantId)
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Merchants)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.NoAction);
            });
            List<tblMerchant> merchants = new List<tblMerchant>
            {
                new tblMerchant { Id = merchantId[0], UserId = userId[0], Name = "Bikini Bottom Power and Communications", Description = "Power and Internet", Website = "none" },
                new tblMerchant { Id = merchantId[1], UserId = userId[0], Name = "First National Bank of Bikini Bottom", Description = "Banking and Morgage", Website = "none" },
                new tblMerchant { Id = merchantId[2], UserId = userId[0], Name = "Quicky Mart", Description = "Retail Store", Website = "none" },
                new tblMerchant { Id = merchantId[3], UserId = userId[1], Name = "Bikini Bottom Power and Communications", Description = "Power and Internet", Website = "none" },
                new tblMerchant { Id = merchantId[4], UserId = userId[1], Name = "First National Bank of Bikini Bottom", Description = "Banking and Mortgage", Website = "none" },
                new tblMerchant { Id = merchantId[5], UserId = userId[1], Name = "Quicky Mart", Description = "Retail Store", Website = "none" },
                new tblMerchant { Id = merchantId[6], UserId = userId[0], Name = "Krusty Krab", Description = "Restaurant", Website = "none" },
                new tblMerchant { Id = merchantId[7], UserId = userId[1], Name = "Krusty Krab", Description = "Restaurant", Website = "none" }
            };
            modelBuilder.Entity<tblMerchant>().HasData(merchants);
        }

        private void CreateAccount(ModelBuilder modelBuilder) 
        {
            for (int i = 0; i < accountId.Length; i++)
            {
                accountId[i] = Guid.NewGuid();
            }

            modelBuilder.Entity<tblAccount>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblAccount");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.StartingBalance).IsRequired();
                entity.Property(e => e.CurrentBalance).IsRequired();
                entity.Property(e => e.AccountCategory).IsRequired();
                entity.Property(e => e.NormalBalance).IsRequired();
                entity.HasMany(e => e.BudgetItems)
                      .WithOne(bi => bi.Account)
                      .HasForeignKey(bi => bi.AccountId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Accounts)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            /**********************
             * 20 Default Accounts per user
             * 
             * Permanent Accounts:
             * 
             * Assets: Cash, Checking, Savings, Retirement, Brokerage, Property
             * Liabilities: Credit card, Loan, Mortgage
             * Equity: Net Worth
             * 
             * Temperary Accounts:
             * 
             * Income: Salary, Secondary Income, Dividend, Interest
             * Expenses: Rent, Groceries, Electricity, Phone, Internet, Taxes
            **********************/
            List<tblAccount> accounts = new List<tblAccount>
            {
                /*Spongebob Accounts*/
                new tblAccount { Id = accountId[0], UserId = userId[0], Name = "Cash", Description = "Spongebob cash account", StartingBalance = 10020m, CurrentBalance = 11055m, AccountCategory = AccountCategory.Asset, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[1], UserId = userId[0], Name = "Checking", Description = "Spongebob checking account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Asset, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[2], UserId = userId[0], Name = "Savings", Description = "Spongebob savings account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Asset, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[3], UserId = userId[0], Name = "Retirement", Description = "Spongebob retirement account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Asset, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[4], UserId = userId[0], Name = "Brokerage", Description = "Spongebob brokerage account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Asset, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[5], UserId = userId[0], Name = "Property", Description = "Spongebob property account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Asset, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[6], UserId = userId[0], Name = "Credit card", Description = "Spongebob credit card account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Liability, NormalBalance = NormalBalance.Credit },
                new tblAccount { Id = accountId[7], UserId = userId[0], Name = "Loan", Description = "Spongebob loan account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Liability, NormalBalance = NormalBalance.Credit },
                new tblAccount { Id = accountId[8], UserId = userId[0], Name = "Morgage", Description = "Spongebob morgage account", StartingBalance = 25000m, CurrentBalance = 24750m, AccountCategory = AccountCategory.Liability, NormalBalance = NormalBalance.Credit },
                new tblAccount { Id = accountId[9], UserId = userId[0], Name = "Net Worth", Description = "Spongebob net worth account", StartingBalance = 0m, CurrentBalance = -14980m, AccountCategory = AccountCategory.Equity, NormalBalance = NormalBalance.Credit },
                new tblAccount { Id = accountId[10], UserId = userId[0], Name = "Income", Description = "Spongebob income account", StartingBalance = 0m, CurrentBalance = 1500m, AccountCategory = AccountCategory.Income, NormalBalance = NormalBalance.Credit },
                new tblAccount { Id = accountId[11], UserId = userId[0], Name = "Secondary Income", Description = "Spongebob secondary income account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Income, NormalBalance = NormalBalance.Credit },
                new tblAccount { Id = accountId[12], UserId = userId[0], Name = "Dividend", Description = "Spongebob dividend account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Income, NormalBalance = NormalBalance.Credit },
                new tblAccount { Id = accountId[13], UserId = userId[0], Name = "Interest", Description = "Spongebob interest account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Income, NormalBalance = NormalBalance.Credit },
                new tblAccount { Id = accountId[14], UserId = userId[0], Name = "Rent", Description = "Spongebob rent account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Expense, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[15], UserId = userId[0], Name = "Groceries", Description = "Spongebob groceries account", StartingBalance = 0m, CurrentBalance = 15m, AccountCategory = AccountCategory.Expense, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[16], UserId = userId[0], Name = "Electricity", Description = "Spongebob electricity account", StartingBalance = 0m, CurrentBalance = 100m, AccountCategory = AccountCategory.Expense, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[17], UserId = userId[0], Name = "Phone", Description = "Spongebob phone account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Expense, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[18], UserId = userId[0], Name = "Internet", Description = "Spongebob internet account", StartingBalance = 0m, CurrentBalance = 100m, AccountCategory = AccountCategory.Expense, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[19], UserId = userId[0], Name = "Taxes", Description = "Spongebob taxes account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Expense, NormalBalance = NormalBalance.Debit },

                /*Squidward Accounts*/

                new tblAccount { Id = accountId[20], UserId = userId[1], Name = "Cash", Description = "Squidward cash account", StartingBalance = 5000m, CurrentBalance = 4050m, AccountCategory = AccountCategory.Asset, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[21], UserId = userId[1], Name = "Checking", Description = "Squidward checking account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Asset, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[22], UserId = userId[1], Name = "Savings", Description = "Squidward savings account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Asset, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[23], UserId = userId[1], Name = "Retirement", Description = "Squidward retirement account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Asset, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[24], UserId = userId[1], Name = "Brokerage", Description = "Squidward brokerage account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Asset, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[25], UserId = userId[1], Name = "Property", Description = "Squidward property account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Asset, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[26], UserId = userId[1], Name = "Credit card", Description = "Squidward credit card account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Liability, NormalBalance = NormalBalance.Credit },
                new tblAccount { Id = accountId[27], UserId = userId[1], Name = "Loan", Description = "Squidward loan account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Liability, NormalBalance = NormalBalance.Credit },
                new tblAccount { Id = accountId[28], UserId = userId[1], Name = "Morgage", Description = "Squidward morgage account", StartingBalance = 50000m, CurrentBalance = 49900m, AccountCategory = AccountCategory.Liability, NormalBalance = NormalBalance.Credit },
                new tblAccount { Id = accountId[29], UserId = userId[1], Name = "Net Worth", Description = "Squidward net worth account", StartingBalance = -45000m, CurrentBalance = 0m, AccountCategory = AccountCategory.Equity, NormalBalance = NormalBalance.Credit },
                new tblAccount { Id = accountId[30], UserId = userId[1], Name = "Income", Description = "Squidward income account", StartingBalance = 0m, CurrentBalance = 1000m, AccountCategory = AccountCategory.Income, NormalBalance = NormalBalance.Credit },
                new tblAccount { Id = accountId[31], UserId = userId[1], Name = "Secondary Income", Description = "Squidward secondary income account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Income, NormalBalance = NormalBalance.Credit },
                new tblAccount { Id = accountId[32], UserId = userId[1], Name = "Dividend", Description = "Squidward dividend account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Income, NormalBalance = NormalBalance.Credit },
                new tblAccount { Id = accountId[33], UserId = userId[1], Name = "Interest", Description = "Squidward interest account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Income, NormalBalance = NormalBalance.Credit },
                new tblAccount { Id = accountId[34], UserId = userId[1], Name = "Rent", Description = "Squidward rent account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Expense, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[35], UserId = userId[1], Name = "Groceries", Description = "Squidward groceries account", StartingBalance = 0m, CurrentBalance = 1500m, AccountCategory = AccountCategory.Expense, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[36], UserId = userId[1], Name = "Electricity", Description = "Squidward electricity account", StartingBalance = 0m, CurrentBalance = 150m, AccountCategory = AccountCategory.Expense, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[37], UserId = userId[1], Name = "Phone", Description = "Squidward phone account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Expense, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[38], UserId = userId[1], Name = "Internet", Description = "Squidward internet account", StartingBalance = 0m, CurrentBalance = 100m, AccountCategory = AccountCategory.Expense, NormalBalance = NormalBalance.Debit },
                new tblAccount { Id = accountId[39], UserId = userId[1], Name = "Taxes", Description = "Squidward taxes account", StartingBalance = 0m, CurrentBalance = 0m, AccountCategory = AccountCategory.Expense, NormalBalance = NormalBalance.Debit }
            };

            modelBuilder.Entity<tblAccount>().HasData(accounts);
        }

        private void CreateItem(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < itemId.Length; i++)
            {
                itemId[i] = Guid.NewGuid();
            }

            modelBuilder.Entity<tblItem>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblItem");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(e => e.ItemPrices)
                      .WithOne(ip => ip.Item)
                      .HasForeignKey(ip => ip.ItemId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            List<tblItem> items = new List<tblItem>
            {
                new tblItem { Id = itemId[0], UserId = userId[0], Name = "Cheese", Description = "24-Slices" },
                new tblItem { Id = itemId[1], UserId = userId[0], Name = "Snail Food", Description = "100-Pounds" },
                new tblItem { Id = itemId[2], UserId = userId[0], Name = "Fishing Net", Description = "Replacement" },
                new tblItem { Id = itemId[3], UserId = userId[1], Name = "Clarinet", Description = "C# Clairy 5000" },
                new tblItem { Id = itemId[4], UserId = userId[1], Name = "Art Paint", Description = "12-Oz Blue" },
                new tblItem { Id = itemId[5], UserId = userId[1], Name = "Napkins", Description = "500-Pack" },
                new tblItem { Id = itemId[6], UserId = userId[0], Name = "Buns", Description = "12-Pack" },
                new tblItem { Id = itemId[7], UserId = userId[0], Name = "Rocks", Description = "1 Rock" },
                new tblItem { Id = itemId[8], UserId = userId[1], Name = "Gas", Description = "10 Gallons" },
                new tblItem { Id = itemId[9], UserId = userId[1], Name = "Cheese", Description = "24-Slices" }
            };

            modelBuilder.Entity<tblItem>().HasData(items);
        }

        private void CreateTransactionCategory(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < transactionCategoryId.Length; i++)
            {
                transactionCategoryId[i] = Guid.NewGuid();
            }

            modelBuilder.Entity<tblTransactionCategory>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblTransactionCategory");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.TransactionCategories)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            List<tblTransactionCategory> transactionCategories = new List<tblTransactionCategory>
            {
                new tblTransactionCategory { Id = transactionCategoryId[0], UserId = userId[0], Name = "Groceries", Description = "Food and household items" },
                new tblTransactionCategory { Id = transactionCategoryId[1], UserId = userId[0], Name = "Utilities", Description = "Electricity, water, gas, etc." },
                new tblTransactionCategory { Id = transactionCategoryId[2], UserId = userId[1], Name = "Groceries", Description = "My food for the month" },
                new tblTransactionCategory { Id = transactionCategoryId[3], UserId = userId[1], Name = "Transportation", Description = "Gas, public transit, etc." },
                new tblTransactionCategory { Id = transactionCategoryId[4], UserId = userId[1], Name = "Utilities", Description = "Rent and bills" },
                new tblTransactionCategory { Id = transactionCategoryId[5], UserId = userId[0], Name = "Income", Description = "Money from various sources" },
                new tblTransactionCategory { Id = transactionCategoryId[6], UserId = userId[1], Name = "Income", Description = "Money from various sources" },
                new tblTransactionCategory { Id = transactionCategoryId[7], UserId = userId[0], Name = "Housing", Description = "Morgage, rent, upkeep" },
                new tblTransactionCategory { Id = transactionCategoryId[8], UserId = userId[1], Name = "Housing", Description = "Morgage, rent, upkeep" }
            };

            modelBuilder.Entity<tblTransactionCategory>().HasData(transactionCategories);
        }

        private void CreateTransaction(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < transactionId.Length; i++)
            {
                transactionId[i] = Guid.NewGuid();
            }

            modelBuilder.Entity<tblTransaction>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblTransaction");
                entity.Property(e => e.Amount).IsRequired();
                entity.Property(e => e.TransactionDate).IsRequired();
                entity.Property(e => e.Memo).HasMaxLength(500);
                entity.Property(e => e.Type).IsRequired();
                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Merchant)
                      .WithMany()
                      .HasForeignKey(e => e.MerchantId)
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.TransactionCategory)
                      .WithMany()
                      .HasForeignKey(e => e.TransactionCategoryId)
                      .OnDelete(DeleteBehavior.NoAction);      
                entity.HasMany(e => e.ItemPrices)
                      .WithOne(ip => ip.Transaction)
                      .HasForeignKey(ip => ip.TransactionId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            List<tblTransaction> transactions = new List<tblTransaction>
            {
                new tblTransaction { Id = transactionId[0], UserId = userId[0], TransactionCategoryId = transactionCategoryId[5], MerchantId = merchantId[6], Amount = 1500.00m, TransactionDate = DateTime.Now.AddDays(-10), Type = TransactionType.Expense, Memo = "Income" },
                new tblTransaction {Id = transactionId[1], UserId = userId[0], TransactionCategoryId = transactionCategoryId[1], MerchantId = merchantId[0], Amount = 100.00m, TransactionDate = DateTime.Now.AddDays(-5), Type = TransactionType.Income, Memo = "Power Payment"},
                new tblTransaction { Id = transactionId[2], UserId = userId[0], TransactionCategoryId = transactionCategoryId[7], MerchantId = merchantId[1], Amount = 250.00m, TransactionDate = DateTime.Now.AddDays(-3), Type = TransactionType.Expense, Memo = "Morgage Payment" },
                new tblTransaction { Id = transactionId[3], UserId = userId[0], TransactionCategoryId = transactionCategoryId[0], MerchantId = merchantId[2], Amount = 15.00m, TransactionDate = DateTime.Now.AddDays(-7), Type = TransactionType.Income, Memo = "Groceries" },
                new tblTransaction { Id = transactionId[4], UserId = userId[0], TransactionCategoryId = transactionCategoryId[1], MerchantId = merchantId[0], Amount = 100.00m, TransactionDate = DateTime.Now.AddDays(-2), Type = TransactionType.Expense, Memo = "Internet Payment" },
                new tblTransaction { Id = transactionId[5], UserId = userId[1], TransactionCategoryId = transactionCategoryId[6], MerchantId = merchantId[7], Amount = 1000.00m, TransactionDate = DateTime.Now.AddDays(-1), Type = TransactionType.Expense, Memo = "Income" },
                new tblTransaction { Id = transactionId[6], UserId = userId[1], TransactionCategoryId = transactionCategoryId[4], MerchantId = merchantId[3], Amount = 150.00m, TransactionDate = DateTime.Now.AddDays(-4), Type = TransactionType.Expense, Memo = "Power Payment" },
                new tblTransaction { Id = transactionId[7], UserId = userId[1], TransactionCategoryId = transactionCategoryId[8], MerchantId = merchantId[4], Amount = 100.00m, TransactionDate = DateTime.Now.AddDays(-6), Type = TransactionType.Expense, Memo = "Morgage Payment" },
                new tblTransaction { Id = transactionId[8], UserId = userId[1], TransactionCategoryId = transactionCategoryId[1], MerchantId = merchantId[5], Amount = 1500.00m, TransactionDate = DateTime.Now.AddDays(-8), Type = TransactionType.Income, Memo = "Groceries" },
                new tblTransaction { Id = transactionId[9], UserId = userId[1], TransactionCategoryId = transactionCategoryId[4], MerchantId = merchantId[3], Amount = 100.00m, TransactionDate = DateTime.Now.AddDays(-9), Type = TransactionType.Expense, Memo = "Internet Payment" }
            };

            modelBuilder.Entity<tblTransaction>().HasData(transactions);
        }
        private void CreateItemPrice(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < itemPriceId.Length; i++)
            {
                itemPriceId[i] = Guid.NewGuid();
            }

            modelBuilder.Entity<tblItemPrices>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblItemPrices");
                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.PurchaseDate).IsRequired();
                entity.HasOne(e => e.Item)
                      .WithMany(i => i.ItemPrices)
                      .HasForeignKey(e => e.ItemId)
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Merchant)
                      .WithMany(m => m.ItemPrices)
                      .HasForeignKey(e => e.MerchantId)
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Transaction)
                      .WithMany(t => t.ItemPrices)
                      .HasForeignKey(e => e.TransactionId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            List<tblItemPrices> itemPrices = new List<tblItemPrices>
            {
                new tblItemPrices { Id = itemPriceId[0], ItemId = itemId[0], MerchantId = merchantId[2], UserId = userId[0], TransactionId = transactionId[3], Price = 15.00m, PurchaseDate = DateTime.Now.AddDays(-7) },
                new tblItemPrices { Id = itemPriceId[1], ItemId = itemId[3], MerchantId = merchantId[5], UserId = userId[1], TransactionId = transactionId[8], Price = 1500.00m, PurchaseDate = DateTime.Now.AddDays(-8) },
            };

            modelBuilder.Entity<tblItemPrices>().HasData(itemPrices);
        }

        private void CreateBudget(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < budgetId.Length; i++)
            {
                budgetId[i] = Guid.NewGuid();
            }

            modelBuilder.Entity<tblBudget>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblBudget");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.StartDate).IsRequired();
                entity.Property(e => e.EndDate).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.UpdatedAt).IsRequired();
                entity.Property(e => e.IsActive).IsRequired();
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Budgets)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            List<tblBudget> budgets = new List<tblBudget>
            {
                new tblBudget { Id = budgetId[0], UserId = userId[0], Name = "Monthly Budget", Description = "Spongebob budget for the month of June", StartDate = new DateTime(2024, 6, 1), EndDate = new DateTime(2024, 6, 30), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsActive = true },
                new tblBudget { Id = budgetId[1], UserId = userId[0], Name = "Vacation Budget", Description = "Budget for the upcoming vacation", StartDate = new DateTime(2024, 7, 1), EndDate = new DateTime(2024, 7, 15), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsActive = true },
                new tblBudget { Id = budgetId[2], UserId = userId[1], Name = "Monthly Budget", Description = "Squidward budget for the month of June", StartDate = new DateTime(2024, 6, 1), EndDate = new DateTime(2024, 6, 30), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsActive = true }
            };

            modelBuilder.Entity<tblBudget>().HasData(budgets);
        }

        private void CreateBudgetItem(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < budgetItemId.Length; i++)
            {
                budgetItemId[i] = Guid.NewGuid();
            }

            modelBuilder.Entity<tblBudgetItem>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblBudgetItem");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Amount).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.UpdatedAt).IsRequired();
                entity.HasOne(e => e.Budget)
                      .WithMany(b => b.BudgetItems)
                      .HasForeignKey(e => e.BudgetId)
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Account)
                      .WithMany(a => a.BudgetItems)
                      .HasForeignKey(e => e.AccountId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            List<tblBudgetItem> budgetItems = new List<tblBudgetItem>
            {
                new tblBudgetItem { Id = budgetItemId[0], BudgetId = budgetId[0], AccountId = accountId[0], Name = "Rent", Description = "Monthly rent payment", Amount = 1200.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new tblBudgetItem { Id = budgetItemId[1], BudgetId = budgetId[0], AccountId = accountId[0], Name = "Groceries", Description = "Monthly groceries", Amount = 300.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new tblBudgetItem { Id = budgetItemId[2], BudgetId = budgetId[1], AccountId = accountId[0], Name = "Flight", Description = "Flight tickets for vacation", Amount = 500.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new tblBudgetItem { Id = budgetItemId[3], BudgetId = budgetId[1], AccountId = accountId[0], Name = "Hotel", Description = "Hotel accommodation for vacation", Amount = 800.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new tblBudgetItem { Id = budgetItemId[4], BudgetId = budgetId[2], AccountId = accountId[1], Name = "Rent", Description = "Monthly rent payment", Amount = 1000.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new tblBudgetItem { Id = budgetItemId[5], BudgetId = budgetId[2], AccountId = accountId[1], Name = "Groceries", Description = "Monthly groceries", Amount = 250.00m, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            };

            modelBuilder.Entity<tblBudgetItem>().HasData(budgetItems);
        }

        private void CreateGoal(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < goalId.Length; i++)
            {
                goalId[i] = Guid.NewGuid();
            }

            modelBuilder.Entity<tblGoal>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblGoal");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Type).IsRequired().HasMaxLength(50);
                entity.Property(e => e.TargetAmount).IsRequired();
                entity.Property(e => e.CurrentAmount).IsRequired();
                entity.Property(e => e.TargetDate).IsRequired();
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Goals)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Account)
                      .WithMany()
                      .HasForeignKey(e => e.AccountId)
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Merchant)
                      .WithMany()
                      .HasForeignKey(e => e.MechantId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            List<tblGoal> goals = new List<tblGoal>
            {
                new tblGoal { Id = goalId[0], UserId = userId[0], AccountId = accountId[0], MechantId = merchantId[0], Name = "Buy a Car", Type = "Savings", TargetAmount = 10000.00m, CurrentAmount = 2500.00m, TargetDate = new DateTime(2025, 12, 31) },
                new tblGoal { Id = goalId[1], UserId = userId[0], AccountId = accountId[1], MechantId = merchantId[1], Name = "Vacation Fund", Type = "Savings", TargetAmount = 5000.00m, CurrentAmount = 1500.00m, TargetDate = new DateTime(2024, 8, 15) },
                new tblGoal { Id = goalId[2], UserId = userId[1], AccountId = accountId[3], MechantId = merchantId[2], Name = "Emergency Fund", Type = "Savings", TargetAmount = 3000.00m, CurrentAmount = 800.00m, TargetDate = new DateTime(2024, 12, 31) }
            };

            modelBuilder.Entity<tblGoal>().HasData(goals);
        }

        private void CreateJournalEntry(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < journalEntryId.Length; i++)
            {
                journalEntryId[i] = Guid.NewGuid();
            }

            modelBuilder.Entity<tblJournalEntry>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblJournalEntry");
                entity.Property(e => e.EntryDate).IsRequired();
                entity.Property(e => e.Memo).HasMaxLength(500);
                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Merchant)
                      .WithMany()
                      .HasForeignKey(e => e.MerchantId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            List<tblJournalEntry> journalEntries = new List<tblJournalEntry>
            {
                new tblJournalEntry { Id = journalEntryId[0], UserId = userId[0], MerchantId = merchantId[6], EntryDate = DateTime.Now.AddDays(-10), Memo = "Payday" },
                new tblJournalEntry { Id = journalEntryId[1], UserId = userId[0], MerchantId = merchantId[0], EntryDate = DateTime.Now.AddDays(-5), Memo = "Power Payment" },
                new tblJournalEntry { Id = journalEntryId[2], UserId = userId[0], MerchantId = merchantId[1], EntryDate = DateTime.Now.AddDays(-3), Memo = "Morgage Payment" },
                new tblJournalEntry { Id = journalEntryId[3], UserId = userId[0], MerchantId = merchantId[2], EntryDate = DateTime.Now.AddDays(-7), Memo = "Groceries" },
                new tblJournalEntry { Id = journalEntryId[4], UserId = userId[0], MerchantId = merchantId[0], EntryDate = DateTime.Now.AddDays(-2), Memo = "Internet Payment" },
                new tblJournalEntry { Id = journalEntryId[5], UserId = userId[1], MerchantId = merchantId[7], EntryDate = DateTime.Now.AddDays(-1), Memo = "Payday" },
                new tblJournalEntry { Id = journalEntryId[6], UserId = userId[1], MerchantId = merchantId[3], EntryDate = DateTime.Now.AddDays(-4), Memo = "Power Payment" },
                new tblJournalEntry { Id = journalEntryId[7], UserId = userId[1], MerchantId = merchantId[4], EntryDate = DateTime.Now.AddDays(-6), Memo = "Morgage Payment" },
                new tblJournalEntry { Id = journalEntryId[8], UserId = userId[1], MerchantId = merchantId[5], EntryDate = DateTime.Now.AddDays(-8), Memo = "Groceries" },
                new tblJournalEntry { Id = journalEntryId[9], UserId = userId[1], MerchantId = merchantId[3], EntryDate = DateTime.Now.AddDays(-9), Memo = "Internet Payment" }
            };
            modelBuilder.Entity<tblJournalEntry>().HasData(journalEntries);
        }

        private void CreateJournalLine(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < journalLineId.Length; i++)
            {
                journalLineId[i] = Guid.NewGuid();
            }

            modelBuilder.Entity<tblJournalLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblJournalLine");
                entity.Property(e => e.Debit).IsRequired();
                entity.Property(e => e.Credit).IsRequired();
                entity.Property(e => e.Memo).HasMaxLength(500);
                entity.HasOne(e => e.JournalEntry)
                      .WithMany(je => je.JournalEntryLines)
                      .HasForeignKey(e => e.JournalEntryId)
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Account)
                      .WithMany()
                      .HasForeignKey(e => e.AccountId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            List<tblJournalLine> journalLines = new List<tblJournalLine>
            {
               new tblJournalLine { Id = journalLineId[0], JournalEntryId = journalEntryId[0], AccountId = accountId[0], Debit = 1500.00m, Credit = 0.00m, Memo = "Income" },
               new tblJournalLine { Id = journalLineId[1], JournalEntryId = journalEntryId[0], AccountId = accountId[10], Debit = 0.00m, Credit = 1500.00m, Memo = "Income" },
                new tblJournalLine { Id = journalLineId[2], JournalEntryId = journalEntryId[1], AccountId = accountId[16], Debit = 100.00m, Credit = 0.00m, Memo = "Power Payment" },
                new tblJournalLine { Id = journalLineId[3], JournalEntryId = journalEntryId[1], AccountId = accountId[0], Debit = 0.00m, Credit = 100.00m, Memo = "Power Payment" },
                new tblJournalLine { Id = journalLineId[4], JournalEntryId = journalEntryId[2], AccountId = accountId[8], Debit = 250.00m, Credit = 0.00m, Memo = "Morgage Payment" },
                new tblJournalLine { Id = journalLineId[5], JournalEntryId = journalEntryId[2], AccountId = accountId[0], Debit = 0.00m, Credit = 250.00m, Memo = "Morgage Payment" },
                new tblJournalLine { Id = journalLineId[6], JournalEntryId = journalEntryId[3], AccountId = accountId[15], Debit = 15.00m, Credit = 0.00m, Memo = "Groceries" },
                new tblJournalLine { Id = journalLineId[7], JournalEntryId = journalEntryId[3], AccountId = accountId[0], Debit = 0.00m, Credit = 15.00m, Memo = "Groceries" },
                new tblJournalLine { Id = journalLineId[8], JournalEntryId = journalEntryId[4], AccountId = accountId[18], Debit = 100.00m, Credit = 0.00m, Memo = "Internet Payment" },
                new tblJournalLine { Id = journalLineId[9], JournalEntryId = journalEntryId[4], AccountId = accountId[0], Debit = 0.00m, Credit = 100.00m, Memo = "Internet Payment" },
                new tblJournalLine { Id = journalLineId[10], JournalEntryId = journalEntryId[5], AccountId = accountId[20], Debit = 1000.00m, Credit = 0.00m, Memo = "Income" },
                new tblJournalLine { Id = journalLineId[11], JournalEntryId = journalEntryId[5], AccountId = accountId[30], Debit = 0.00m, Credit = 1000.00m, Memo = "Income" },
                new tblJournalLine { Id = journalLineId[12], JournalEntryId = journalEntryId[6], AccountId = accountId[36], Debit = 150.00m, Credit = 0.00m, Memo = "Power Payment" },
                new tblJournalLine { Id = journalLineId[13], JournalEntryId = journalEntryId[6], AccountId = accountId[20], Debit = 0.00m, Credit = 150.00m, Memo = "Power Payment" },
                new tblJournalLine { Id = journalLineId[14], JournalEntryId = journalEntryId[7], AccountId = accountId[28], Debit = 100.00m, Credit = 0.00m, Memo = "Morgage Payment" },
                new tblJournalLine { Id = journalLineId[15], JournalEntryId = journalEntryId[7], AccountId = accountId[20], Debit = 0.00m, Credit = 100.00m, Memo = "Morgage Payment" },
                new tblJournalLine { Id = journalLineId[16], JournalEntryId = journalEntryId[8], AccountId = accountId[35], Debit = 1500.00m, Credit = 0.00m, Memo = "Groceries" },
                new tblJournalLine { Id = journalLineId[17], JournalEntryId = journalEntryId[8], AccountId = accountId[20], Debit = 0.00m, Credit = 1500.00m, Memo = "Groceries" },
                new tblJournalLine { Id = journalLineId[18], JournalEntryId = journalEntryId[9], AccountId = accountId[38], Debit = 100.00m, Credit = 0.00m, Memo = "Internet Payment" },
                new tblJournalLine { Id = journalLineId[19], JournalEntryId = journalEntryId[9], AccountId = accountId[20], Debit = 0.00m, Credit = 100.00m, Memo = "Internet Payment" },

            };

            modelBuilder.Entity<tblJournalLine>().HasData(journalLines);
        }

        private void CreateCurrencyExchange(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < currencyExchangeId.Length; i++)
            {
                currencyExchangeId[i] = Guid.NewGuid();
            }

            modelBuilder.Entity<tblCurrencyExchange>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblCurrencyExchange");
                entity.Property(e => e.ExchangeRate).IsRequired();
                entity.Property(e => e.ExchangeDate).IsRequired();
                entity.HasOne(e => e.FromCurrency)
                      .WithMany()
                      .HasForeignKey(e => e.FromCurrencyId)
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.ToCurrency)
                      .WithMany()
                      .HasForeignKey(e => e.ToCurrencyId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            List<tblCurrencyExchange> currencyExchanges = new List<tblCurrencyExchange>
            {
                new tblCurrencyExchange { Id = currencyExchangeId[0], FromCurrencyId = currencyId[0], ToCurrencyId = currencyId[1], ExchangeRate = 0.85m, ExchangeDate = DateTime.Now.AddDays(-10) },
                new tblCurrencyExchange { Id = currencyExchangeId[1], FromCurrencyId = currencyId[1], ToCurrencyId = currencyId[0], ExchangeRate = 1.18m, ExchangeDate = DateTime.Now.AddDays(-5) },
                new tblCurrencyExchange { Id = currencyExchangeId[2], FromCurrencyId = currencyId[0], ToCurrencyId = currencyId[1], ExchangeRate = 0.84m, ExchangeDate = DateTime.Now.AddDays(-3) }
            };

            modelBuilder.Entity<tblCurrencyExchange>().HasData(currencyExchanges);
        }

        private static string GetHash(string password)
        {
            using (var hasher = SHA256.Create())
            {
                var hashBytes = System.Text.Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(hasher.ComputeHash(hashBytes));
            }
        }
    }
}