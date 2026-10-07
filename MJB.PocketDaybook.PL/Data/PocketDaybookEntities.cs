using MJB.PocketDaybook.PL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace MJB.PocketDaybook.PL.Data
{
    public class PocketDaybookEntities : DbContext
    {
        Guid[] userId = new Guid[2];
        Guid[] currencyId = new Guid[2];
        Guid[] merchantId = new Guid[5];
        Guid[] accountId = new Guid[6];
        Guid[] itemId = new Guid[10];
        Guid[] itemPriceId = new Guid[10];
        Guid[] transactionCategoryId = new Guid[5];
        Guid[] transactionId = new Guid[10];
        Guid[] budgetId = new Guid[3];
        Guid[] budgetItemId = new Guid[6];
        Guid[] goalId = new Guid[3];
        Guid[] journalEntryId = new Guid[3];
        Guid[] journalLineId = new Guid[6];
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
            CreateItemPrice(modelBuilder);
            CreateTransactionCategory(modelBuilder);
            CreateTransaction(modelBuilder);
            CreateBudget(modelBuilder);
            CreateBudgetItem(modelBuilder);
            CreateGoal(modelBuilder);
            CreateJournalEntry(modelBuilder);
            CreateJournalLine(modelBuilder);
            CreateCurrencyExchange(modelBuilder);
        }

        private void CreateUser(ModelBuilder modelBuilder)
        {
            for(int i = 0; i < userId.Length; i++)
            {
                userId[i] = Guid.NewGuid();
            }

            modelBuilder.Entity<tblUser>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
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
                new tblUser { Id = userId[0], Name = "SpongeBob" },
                new tblUser { Id = userId[1], Name = "Squidward" }
            };

            modelBuilder.Entity<tblUser>().HasData(users);
        }

        private void CreateCurrency(ModelBuilder modelBuilder)
        {
            for(int i = 0; i < currencyId.Length; i++)
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
            for(int i = 0; i < merchantId.Length; i++)
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
                new tblMerchant { Id = merchantId[0], UserId = userId[0], Name = "Amazon", Description = "Online Retailer", Website = "https://www.amazon.com" },
                new tblMerchant { Id = merchantId[1], UserId = userId[0], Name = "Walmart", Description = "Retail Store", Website = "https://www.walmart.com" },
                new tblMerchant { Id = merchantId[2], UserId = userId[1], Name = "Target", Description = "Retail Store", Website = "https://www.target.com" },
                new tblMerchant { Id = merchantId[3], UserId = userId[1], Name = "Best Buy", Description = "Electronics Retailer", Website = "https://www.bestbuy.com" },
                new tblMerchant { Id = merchantId[4], UserId = userId[1], Name = "Costco", Description = "Wholesale Retailer", Website = "https://www.costco.com" }
            };
            modelBuilder.Entity<tblMerchant>().HasData(merchants);
        }

        private void CreateAccount(ModelBuilder modelBuilder)
        {
            for(int i = 0; i < accountId.Length; i++)
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

            List<tblAccount> accounts = new List<tblAccount>
            {
                new tblAccount { Id = accountId[0], UserId = userId[0], Name = "Cash", Description = "Spongebob cash account", StartingBalance = 0m, CurrentBalance = 500m, AccountCategory = AccountCategory.Asset, NormalBalance = NormalBalance.Debit },

                new tblAccount { Id = accountId[1], UserId = userId[0], Name = "Accounts Payable", Description = "Spongebob total payables", StartingBalance = 0m, CurrentBalance = 750m, AccountCategory = AccountCategory.Liability, NormalBalance = NormalBalance.Credit },

                new tblAccount { Id = accountId[2], UserId = userId[0], Name = "Wages receivable", Description = "Spongebob wages receivable", StartingBalance = 0.00m, CurrentBalance = 500.00m, AccountCategory = AccountCategory.Income, NormalBalance = NormalBalance.Credit },

                new tblAccount { Id = accountId[3], UserId = userId[1], Name = "Cash", Description = "Squidward cash account", StartingBalance = 0m, CurrentBalance = 500m, AccountCategory = AccountCategory.Asset, NormalBalance = NormalBalance.Debit },

                new tblAccount { Id = accountId[4], UserId = userId[1], Name = "Accounts Payable", Description = "Squidward total payables", StartingBalance = 0.00m, CurrentBalance = 1000.00m, AccountCategory = AccountCategory.Liability, NormalBalance = NormalBalance.Credit },

                new tblAccount { Id = accountId[5], UserId = userId[1], Name = "Wages receivable", Description = "Squidward wages receivable", StartingBalance = 0.00m, CurrentBalance = 200.00m, AccountCategory = AccountCategory.Income, NormalBalance = NormalBalance.Credit },  

            };  

            modelBuilder.Entity<tblAccount>().HasData(accounts);
        }

        private void CreateItem(ModelBuilder modelBuilder)
        {
            for(int i = 0; i < itemId.Length; i++)
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

        private void CreateItemPrice(ModelBuilder modelBuilder)
        {
            for(int i = 0; i < itemPriceId.Length; i++)
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
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Merchant)
                      .WithMany(m => m.ItemPrices)
                      .HasForeignKey(e => e.MerchantId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            List<tblItemPrices> itemPrices = new List<tblItemPrices>
            {
                new tblItemPrices { Id = itemPriceId[0], ItemId = itemId[0], MerchantId = merchantId[0], Price = 5.99m, PurchaseDate = DateTime.Now.AddDays(-10) },
                new tblItemPrices { Id = itemPriceId[1], ItemId = itemId[1], MerchantId = merchantId[1], Price = 15.49m, PurchaseDate = DateTime.Now.AddDays(-5) },
                new tblItemPrices { Id = itemPriceId[2], ItemId = itemId[2], MerchantId = merchantId[2], Price = 25.00m, PurchaseDate = DateTime.Now.AddDays(-3) },
                new tblItemPrices { Id = itemPriceId[3], ItemId = itemId[3], MerchantId = merchantId[3], Price = 199.99m, PurchaseDate = DateTime.Now.AddDays(-7) },
                new tblItemPrices { Id = itemPriceId[4], ItemId = itemId[4], MerchantId = merchantId[4], Price = 12.75m, PurchaseDate = DateTime.Now.AddDays(-2) },
                new tblItemPrices { Id = itemPriceId[5], ItemId = itemId[5], MerchantId = merchantId[0], Price = 8.99m, PurchaseDate = DateTime.Now.AddDays(-1) },
                new tblItemPrices { Id = itemPriceId[6], ItemId = itemId[6], MerchantId = merchantId[1], Price = 3.49m, PurchaseDate = DateTime.Now.AddDays(-4) },
                new tblItemPrices { Id = itemPriceId[7], ItemId = itemId[7], MerchantId = merchantId[2], Price = 1.99m, PurchaseDate = DateTime.Now.AddDays(-6) },
                new tblItemPrices { Id = itemPriceId[8], ItemId = itemId[8], MerchantId = merchantId[3], Price = 30.00m, PurchaseDate = DateTime.Now.AddDays(-8) },
                new tblItemPrices { Id = itemPriceId[9], ItemId = itemId[9], MerchantId = merchantId[4], Price = 6.49m, PurchaseDate = DateTime.Now.AddDays(-9) }
            };

            modelBuilder.Entity<tblItemPrices>().HasData(itemPrices);
        }

        private void CreateTransactionCategory(ModelBuilder modelBuilder)
        {
            for(int i = 0; i < transactionCategoryId.Length; i++)
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
                new tblTransactionCategory { Id = transactionCategoryId[4], UserId = userId[1], Name = "Utilities", Description = "Rent and bills" }
            };

            modelBuilder.Entity<tblTransactionCategory>().HasData(transactionCategories);
        }

        private void CreateTransaction(ModelBuilder modelBuilder)
        {
            for(int i = 0; i < transactionId.Length; i++)
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
                entity.HasOne(e => e.SourceAccount)
                      .WithMany()
                      .HasForeignKey(e => e.SourceAccountId)
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.DestinationAccount)
                      .WithMany()
                      .HasForeignKey(e => e.DestinationAccountId)
                      .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.TransactionCategory)
                      .WithMany()
                      .HasForeignKey(e => e.TransactionCategoryId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            List<tblTransaction> transactions = new List<tblTransaction>
            {
                new tblTransaction { Id = transactionId[0], UserId = userId[0], SourceAccountId = accountId[0], DestinationAccountId = accountId[1], TransactionCategoryId = transactionCategoryId[0], Amount = 50.00m, TransactionDate = DateTime.Now.AddDays(-10), Type = TransactionType.Expense, Memo = "Grocery shopping" },
                new tblTransaction { Id = transactionId[1], UserId = userId[0], SourceAccountId = accountId[2], DestinationAccountId = accountId[0], TransactionCategoryId = transactionCategoryId[1], Amount = 100.00m, TransactionDate = DateTime.Now.AddDays(-5), Type = TransactionType.Income, Memo = "Salary payment" },
                new tblTransaction { Id = transactionId[2], UserId = userId[1], SourceAccountId = accountId[3], DestinationAccountId = accountId[4], TransactionCategoryId = transactionCategoryId[2], Amount = 75.00m, TransactionDate = DateTime.Now.AddDays(-3), Type = TransactionType.Expense, Memo = "Grocery shopping" },
                new tblTransaction { Id = transactionId[3], UserId = userId[1], SourceAccountId = accountId[5], DestinationAccountId = accountId[3], TransactionCategoryId = transactionCategoryId[3], Amount = 200.00m, TransactionDate = DateTime.Now.AddDays(-7), Type = TransactionType.Income, Memo = "Freelance project payment" },
                new tblTransaction { Id = transactionId[4], UserId = userId[0], SourceAccountId = accountId[1], DestinationAccountId = accountId[2], TransactionCategoryId = transactionCategoryId[4], Amount = 30.00m, TransactionDate = DateTime.Now.AddDays(-2), Type = TransactionType.Expense, Memo = "Utility bill payment" },
                new tblTransaction { Id = transactionId[5], UserId = userId[1], SourceAccountId = accountId[4], DestinationAccountId = accountId[5], TransactionCategoryId = transactionCategoryId[0], Amount = 60.00m, TransactionDate = DateTime.Now.AddDays(-1), Type = TransactionType.Expense, Memo = "Grocery shopping" },
                new tblTransaction { Id = transactionId[6], UserId = userId[0], SourceAccountId = accountId[0], DestinationAccountId = accountId[1], TransactionCategoryId = transactionCategoryId[1], Amount = 40.00m, TransactionDate = DateTime.Now.AddDays(-4), Type = TransactionType.Expense, Memo = "Utility bill payment" },
                new tblTransaction { Id = transactionId[7], UserId = userId[1], SourceAccountId = accountId[3], DestinationAccountId = accountId[4], TransactionCategoryId = transactionCategoryId[2], Amount = 90.00m, TransactionDate = DateTime.Now.AddDays(-6), Type = TransactionType.Expense, Memo = "Grocery shopping" },
                new tblTransaction { Id = transactionId[8], UserId = userId[0], SourceAccountId = accountId[2], DestinationAccountId = accountId[0], TransactionCategoryId = transactionCategoryId[3], Amount = 150.00m, TransactionDate = DateTime.Now.AddDays(-8), Type = TransactionType.Income, Memo = "Freelance project payment" },
                new tblTransaction { Id = transactionId[9], UserId = userId[1], SourceAccountId = accountId[5], DestinationAccountId = accountId[3], TransactionCategoryId = transactionCategoryId[4], Amount = 25.00m, TransactionDate = DateTime.Now.AddDays(-9), Type = TransactionType.Expense, Memo = "Utility bill payment" }
            };

            modelBuilder.Entity<tblTransaction>().HasData(transactions);
        }

        private void CreateBudget(ModelBuilder modelBuilder)
        {
            for(int i = 0; i < budgetId.Length; i++)
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
            for(int i = 0; i < budgetItemId.Length; i++)
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
            for(int i = 0; i < goalId.Length; i++)
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
            for(int i = 0; i < journalEntryId.Length; i++)
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
                new tblJournalEntry { Id = journalEntryId[0], UserId = userId[0], MerchantId = merchantId[0], EntryDate = DateTime.Now.AddDays(-10), Memo = "Grocery shopping at Amazon" },
                new tblJournalEntry { Id = journalEntryId[1], UserId = userId[0], MerchantId = merchantId[1], EntryDate = DateTime.Now.AddDays(-5), Memo = "Bought a new fishing net from Walmart" },
                new tblJournalEntry { Id = journalEntryId[2], UserId = userId[1], MerchantId = merchantId[2], EntryDate = DateTime.Now.AddDays(-3), Memo = "Purchased art supplies from Target" }
            };
            modelBuilder.Entity<tblJournalEntry>().HasData(journalEntries);
        }

        private void CreateJournalLine(ModelBuilder modelBuilder)
        {
            for(int i = 0; i < journalLineId.Length; i++)
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
               new tblJournalLine { Id = journalLineId[0], JournalEntryId = journalEntryId[0], AccountId = accountId[0], Debit = 50.00m, Credit = 0.00m, Memo = "Grocery shopping at Amazon" },
                new tblJournalLine { Id = journalLineId[1], JournalEntryId = journalEntryId[0], AccountId = accountId[1], Debit = 0.00m, Credit = 50.00m, Memo = "Grocery shopping at Amazon" },
                new tblJournalLine { Id = journalLineId[2], JournalEntryId = journalEntryId[1], AccountId = accountId[0], Debit = 25.00m, Credit = 0.00m, Memo = "Bought a new fishing net from Walmart" },
                new tblJournalLine { Id = journalLineId[3], JournalEntryId = journalEntryId[1], AccountId = accountId[1], Debit = 0.00m, Credit = 25.00m, Memo = "Bought a new fishing net from Walmart" },
                new tblJournalLine { Id = journalLineId[4], JournalEntryId = journalEntryId[2], AccountId = accountId[0], Debit = 75.00m, Credit = 0.00m, Memo = "Purchased art supplies from Target" },
                new tblJournalLine { Id = journalLineId[5], JournalEntryId = journalEntryId[2], AccountId = accountId[1], Debit = 0.00m, Credit = 75.00m, Memo = "Purchased art supplies from Target" }

            };  

            modelBuilder.Entity<tblJournalLine>().HasData(journalLines);
        }

        private void CreateCurrencyExchange(ModelBuilder modelBuilder)
        {
            for(int i = 0; i < currencyExchangeId.Length; i++)
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
    }
}