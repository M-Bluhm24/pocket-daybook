using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MJB.PocketDaybook.PL.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCurrency",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DecimalPlaces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCurrency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCurrencyExchange",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromCurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToCurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExchangeDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCurrencyExchange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCurrencyExchange_tblCurrency_FromCurrencyId",
                        column: x => x.FromCurrencyId,
                        principalTable: "tblCurrency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblCurrencyExchange_tblCurrency_ToCurrencyId",
                        column: x => x.ToCurrencyId,
                        principalTable: "tblCurrency",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountCategory = table.Column<int>(type: "int", nullable: false),
                    NormalBalance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblAccount_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblBudgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBudget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblBudgets_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblItem_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMerchant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMerchant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblMerchant_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblTransactionCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTransactionCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblTransactionCategory_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblBudgetItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BudgetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBudgetItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblBudgetItem_tblAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "tblAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblBudgetItem_tblBudgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "tblBudgets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblGoal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MechantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TargetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TargetDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGoal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblGoal_tblAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "tblAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblGoal_tblMerchant_MechantId",
                        column: x => x.MechantId,
                        principalTable: "tblMerchant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblGoal_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblItemPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MerchantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblItemPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblItemPrices_tblItem_ItemId",
                        column: x => x.ItemId,
                        principalTable: "tblItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblItemPrices_tblMerchant_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "tblMerchant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblJournalEntry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MerchantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Memo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblJournalEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblJournalEntry_tblMerchant_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "tblMerchant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblJournalEntry_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblTransaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinationAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Memo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblTransaction_tblAccount_DestinationAccountId",
                        column: x => x.DestinationAccountId,
                        principalTable: "tblAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblTransaction_tblAccount_SourceAccountId",
                        column: x => x.SourceAccountId,
                        principalTable: "tblAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblTransaction_tblTransactionCategory_TransactionCategoryId",
                        column: x => x.TransactionCategoryId,
                        principalTable: "tblTransactionCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblTransaction_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblJournalLine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JournalEntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Memo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblJournalLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblJournalLine_tblAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "tblAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblJournalLine_tblJournalEntry_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalTable: "tblJournalEntry",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "tblCurrency",
                columns: new[] { "Id", "Code", "DecimalPlaces", "Name", "Symbol" },
                values: new object[,]
                {
                    { new Guid("3f65c461-16e9-4633-af06-e9d5d2c08beb"), "EUR", 2, "Euro", "€" },
                    { new Guid("95ae836f-71da-4093-812c-b7a8d4b35391"), "USD", 2, "US Dollar", "$" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad"), "Squidward" },
                    { new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb"), "SpongeBob" }
                });

            migrationBuilder.InsertData(
                table: "tblAccount",
                columns: new[] { "Id", "AccountCategory", "CurrentBalance", "Description", "Name", "NormalBalance", "StartingBalance", "UserId" },
                values: new object[,]
                {
                    { new Guid("39e1a12d-1b1c-421e-ab30-b26271958ee6"), 5, 750m, "Spongebob total payables", "Accounts Payable", 2, 0m, new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") },
                    { new Guid("49f0e278-7dd6-4d88-928b-21595d90e2f4"), 5, 1000.00m, "Squidward total payables", "Accounts Payable", 2, 0.00m, new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") },
                    { new Guid("6cdee046-d1b6-4eb8-b558-1293bb8c1386"), 1, 500m, "Squidward cash account", "Cash", 1, 0m, new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") },
                    { new Guid("b614e031-efed-4c4a-ae98-67c31d8f57d5"), 1, 500m, "Spongebob cash account", "Cash", 1, 0m, new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") },
                    { new Guid("ef2e45f0-fa60-4664-afdc-72b2fcddd687"), 6, 200.00m, "Squidward wages receivable", "Wages receivable", 2, 0.00m, new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") },
                    { new Guid("f6358326-9818-47a5-90c7-893519bc74b5"), 6, 500.00m, "Spongebob wages receivable", "Wages receivable", 2, 0.00m, new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") }
                });

            migrationBuilder.InsertData(
                table: "tblBudgets",
                columns: new[] { "Id", "CreatedAt", "Description", "EndDate", "IsActive", "Name", "StartDate", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("4f7e2b30-1ffb-4107-86c4-48caf7c45dcc"), new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(7540), "Budget for the upcoming vacation", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Vacation Budget", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(7541), new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") },
                    { new Guid("8806acd7-ca9e-433e-a0f8-490602cfe4d8"), new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(7543), "Squidward budget for the month of June", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Monthly Budget", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(7544), new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") },
                    { new Guid("9f9e5396-384f-44c6-9288-daf0c47b3b6c"), new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(7535), "Spongebob budget for the month of June", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Monthly Budget", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(7536), new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") }
                });

            migrationBuilder.InsertData(
                table: "tblCurrencyExchange",
                columns: new[] { "Id", "ExchangeDate", "ExchangeRate", "FromCurrencyId", "ToCurrencyId" },
                values: new object[,]
                {
                    { new Guid("0404cfd0-ca74-4805-9881-29a0718870ca"), new DateTime(2026, 10, 1, 23, 0, 22, 10, DateTimeKind.Local).AddTicks(6874), 1.18m, new Guid("3f65c461-16e9-4633-af06-e9d5d2c08beb"), new Guid("95ae836f-71da-4093-812c-b7a8d4b35391") },
                    { new Guid("3e197402-599b-43a1-8adc-841d6e4de98f"), new DateTime(2026, 9, 26, 23, 0, 22, 10, DateTimeKind.Local).AddTicks(6857), 0.85m, new Guid("95ae836f-71da-4093-812c-b7a8d4b35391"), new Guid("3f65c461-16e9-4633-af06-e9d5d2c08beb") },
                    { new Guid("c7fa5696-c3a6-470c-8a66-4d62315cd781"), new DateTime(2026, 10, 3, 23, 0, 22, 10, DateTimeKind.Local).AddTicks(6876), 0.84m, new Guid("95ae836f-71da-4093-812c-b7a8d4b35391"), new Guid("3f65c461-16e9-4633-af06-e9d5d2c08beb") }
                });

            migrationBuilder.InsertData(
                table: "tblItem",
                columns: new[] { "Id", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("3ffe94ac-2cf5-4361-bd69-5234aca2a6f4"), "100-Pounds", "Snail Food", new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") },
                    { new Guid("4a121e38-8f2e-4de3-93e1-dcb21a07a174"), "10 Gallons", "Gas", new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") },
                    { new Guid("b02e972c-9ae6-4d38-b4e5-49094060817f"), "Replacement", "Fishing Net", new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") },
                    { new Guid("bed05f38-3337-4959-8b8f-5ea797e1538e"), "24-Slices", "Cheese", new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") },
                    { new Guid("bee9d512-8253-4bc5-be77-2ca536bb2d27"), "C# Clairy 5000", "Clarinet", new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") },
                    { new Guid("c9af5c23-9da1-4848-b1f2-5909e6555851"), "12-Oz Blue", "Art Paint", new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") },
                    { new Guid("cf7dd96c-3632-4728-a5d1-d28769dad70d"), "500-Pack", "Napkins", new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") },
                    { new Guid("d58db43e-9b42-4544-9aa5-725eeba13cdb"), "24-Slices", "Cheese", new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") },
                    { new Guid("dd4b0175-bfc2-45aa-bbd8-7f76bb1cf259"), "1 Rock", "Rocks", new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") },
                    { new Guid("f692150d-59d7-4f49-bbd2-83f7f8a8109f"), "12-Pack", "Buns", new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") }
                });

            migrationBuilder.InsertData(
                table: "tblMerchant",
                columns: new[] { "Id", "Description", "Name", "UserId", "Website" },
                values: new object[,]
                {
                    { new Guid("16ce92c7-c9ba-4caa-a6c6-228c12e9459e"), "Online Retailer", "Amazon", new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb"), "https://www.amazon.com" },
                    { new Guid("28677cdf-221b-422e-b1da-bb74347313e9"), "Retail Store", "Target", new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad"), "https://www.target.com" },
                    { new Guid("35e3239b-a76e-465a-922a-dece4275e89f"), "Electronics Retailer", "Best Buy", new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad"), "https://www.bestbuy.com" },
                    { new Guid("c2c9ae04-4584-4b26-9e5a-3cd80c31e058"), "Wholesale Retailer", "Costco", new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad"), "https://www.costco.com" },
                    { new Guid("f66baa82-3faa-413c-943c-8690694d82ea"), "Retail Store", "Walmart", new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb"), "https://www.walmart.com" }
                });

            migrationBuilder.InsertData(
                table: "tblTransactionCategory",
                columns: new[] { "Id", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("9431024f-b5c9-42d2-be6b-e5f5fbe97f19"), "My food for the month", "Groceries", new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") },
                    { new Guid("a293d90c-61c2-4d93-84b8-6611a8c09f75"), "Electricity, water, gas, etc.", "Utilities", new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") },
                    { new Guid("b1c1e2e4-0c28-4c42-9eff-d1f28e009c92"), "Food and household items", "Groceries", new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") },
                    { new Guid("b22f78c8-6087-49db-80e6-c7fe913123c1"), "Gas, public transit, etc.", "Transportation", new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") },
                    { new Guid("b5eff47d-996a-4b08-81e4-300d672e02f8"), "Rent and bills", "Utilities", new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") }
                });

            migrationBuilder.InsertData(
                table: "tblBudgetItem",
                columns: new[] { "Id", "AccountId", "Amount", "BudgetId", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("087594b2-6dc5-4885-8316-e5708eeb166a"), new Guid("b614e031-efed-4c4a-ae98-67c31d8f57d5"), 500.00m, new Guid("4f7e2b30-1ffb-4107-86c4-48caf7c45dcc"), new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(8700), "Flight tickets for vacation", "Flight", new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(8701) },
                    { new Guid("3021aa0a-eb16-4f25-9ae8-4cf322829955"), new Guid("b614e031-efed-4c4a-ae98-67c31d8f57d5"), 300.00m, new Guid("9f9e5396-384f-44c6-9288-daf0c47b3b6c"), new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(8696), "Monthly groceries", "Groceries", new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(8697) },
                    { new Guid("7685a445-2b41-432c-bf08-2af7fba2a622"), new Guid("39e1a12d-1b1c-421e-ab30-b26271958ee6"), 1000.00m, new Guid("8806acd7-ca9e-433e-a0f8-490602cfe4d8"), new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(8706), "Monthly rent payment", "Rent", new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(8707) },
                    { new Guid("a307301a-34ba-4242-9964-9d5e685bdb3a"), new Guid("b614e031-efed-4c4a-ae98-67c31d8f57d5"), 1200.00m, new Guid("9f9e5396-384f-44c6-9288-daf0c47b3b6c"), new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(8686), "Monthly rent payment", "Rent", new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(8692) },
                    { new Guid("a4f8d563-cbf3-4a9f-9557-24836ae030f9"), new Guid("39e1a12d-1b1c-421e-ab30-b26271958ee6"), 250.00m, new Guid("8806acd7-ca9e-433e-a0f8-490602cfe4d8"), new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(8710), "Monthly groceries", "Groceries", new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(8710) },
                    { new Guid("a972f077-abfb-438d-9902-4583895b6a90"), new Guid("b614e031-efed-4c4a-ae98-67c31d8f57d5"), 800.00m, new Guid("4f7e2b30-1ffb-4107-86c4-48caf7c45dcc"), new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(8703), "Hotel accommodation for vacation", "Hotel", new DateTime(2026, 10, 6, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(8704) }
                });

            migrationBuilder.InsertData(
                table: "tblGoal",
                columns: new[] { "Id", "AccountId", "CurrentAmount", "MechantId", "Name", "TargetAmount", "TargetDate", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("573f8e18-03a6-42dd-9db4-12168159645e"), new Guid("39e1a12d-1b1c-421e-ab30-b26271958ee6"), 1500.00m, new Guid("f66baa82-3faa-413c-943c-8690694d82ea"), "Vacation Fund", 5000.00m, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Savings", new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") },
                    { new Guid("88e8a6ef-a62a-4ae1-93ff-a12340a96e6c"), new Guid("b614e031-efed-4c4a-ae98-67c31d8f57d5"), 2500.00m, new Guid("16ce92c7-c9ba-4caa-a6c6-228c12e9459e"), "Buy a Car", 10000.00m, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Savings", new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") },
                    { new Guid("c0938ac9-68e1-4c4f-9117-3e18d05b8c41"), new Guid("6cdee046-d1b6-4eb8-b558-1293bb8c1386"), 800.00m, new Guid("28677cdf-221b-422e-b1da-bb74347313e9"), "Emergency Fund", 3000.00m, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Savings", new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") }
                });

            migrationBuilder.InsertData(
                table: "tblItemPrices",
                columns: new[] { "Id", "ItemId", "MerchantId", "Price", "PurchaseDate" },
                values: new object[,]
                {
                    { new Guid("0c8320fa-b9ae-45bd-bea2-ad923cccdcbf"), new Guid("f692150d-59d7-4f49-bbd2-83f7f8a8109f"), new Guid("f66baa82-3faa-413c-943c-8690694d82ea"), 3.49m, new DateTime(2026, 10, 2, 23, 0, 22, 4, DateTimeKind.Local).AddTicks(102) },
                    { new Guid("16b43d3a-6b3f-4e69-8d64-888da25f7ccc"), new Guid("c9af5c23-9da1-4848-b1f2-5909e6555851"), new Guid("c2c9ae04-4584-4b26-9e5a-3cd80c31e058"), 12.75m, new DateTime(2026, 10, 4, 23, 0, 22, 4, DateTimeKind.Local).AddTicks(98) },
                    { new Guid("4b763142-5b4a-45fe-8406-57090e94f62f"), new Guid("bed05f38-3337-4959-8b8f-5ea797e1538e"), new Guid("16ce92c7-c9ba-4caa-a6c6-228c12e9459e"), 5.99m, new DateTime(2026, 9, 26, 23, 0, 22, 4, DateTimeKind.Local).AddTicks(44) },
                    { new Guid("4b867900-4c1f-481f-97ad-73103b98853d"), new Guid("3ffe94ac-2cf5-4361-bd69-5234aca2a6f4"), new Guid("f66baa82-3faa-413c-943c-8690694d82ea"), 15.49m, new DateTime(2026, 10, 1, 23, 0, 22, 4, DateTimeKind.Local).AddTicks(91) },
                    { new Guid("5b936a3c-becc-4167-85bf-1a71f1c7edf0"), new Guid("4a121e38-8f2e-4de3-93e1-dcb21a07a174"), new Guid("35e3239b-a76e-465a-922a-dece4275e89f"), 30.00m, new DateTime(2026, 9, 28, 23, 0, 22, 4, DateTimeKind.Local).AddTicks(106) },
                    { new Guid("6004ef99-e692-4d6d-8b97-9c8d82c488e4"), new Guid("dd4b0175-bfc2-45aa-bbd8-7f76bb1cf259"), new Guid("28677cdf-221b-422e-b1da-bb74347313e9"), 1.99m, new DateTime(2026, 9, 30, 23, 0, 22, 4, DateTimeKind.Local).AddTicks(104) },
                    { new Guid("7126d884-4937-4f2e-882d-a46ba05b4568"), new Guid("b02e972c-9ae6-4d38-b4e5-49094060817f"), new Guid("28677cdf-221b-422e-b1da-bb74347313e9"), 25.00m, new DateTime(2026, 10, 3, 23, 0, 22, 4, DateTimeKind.Local).AddTicks(94) },
                    { new Guid("aed63234-286d-498a-9aa8-a1e0707bff29"), new Guid("cf7dd96c-3632-4728-a5d1-d28769dad70d"), new Guid("16ce92c7-c9ba-4caa-a6c6-228c12e9459e"), 8.99m, new DateTime(2026, 10, 5, 23, 0, 22, 4, DateTimeKind.Local).AddTicks(100) },
                    { new Guid("b64bddaa-f6ad-4d0a-84cc-28a03b4b6085"), new Guid("d58db43e-9b42-4544-9aa5-725eeba13cdb"), new Guid("c2c9ae04-4584-4b26-9e5a-3cd80c31e058"), 6.49m, new DateTime(2026, 9, 27, 23, 0, 22, 4, DateTimeKind.Local).AddTicks(108) },
                    { new Guid("b9a79170-95f3-4502-a639-200e8a96d594"), new Guid("bee9d512-8253-4bc5-be77-2ca536bb2d27"), new Guid("35e3239b-a76e-465a-922a-dece4275e89f"), 199.99m, new DateTime(2026, 9, 29, 23, 0, 22, 4, DateTimeKind.Local).AddTicks(96) }
                });

            migrationBuilder.InsertData(
                table: "tblJournalEntry",
                columns: new[] { "Id", "EntryDate", "Memo", "MerchantId", "UserId" },
                values: new object[,]
                {
                    { new Guid("032bb43d-1666-48f2-a774-d3ffd333474d"), new DateTime(2026, 10, 3, 23, 0, 22, 9, DateTimeKind.Local).AddTicks(5238), "Purchased art supplies from Target", new Guid("28677cdf-221b-422e-b1da-bb74347313e9"), new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") },
                    { new Guid("ac2c3b99-7fa4-4fd6-9f82-65037674aca2"), new DateTime(2026, 9, 26, 23, 0, 22, 9, DateTimeKind.Local).AddTicks(5218), "Grocery shopping at Amazon", new Guid("16ce92c7-c9ba-4caa-a6c6-228c12e9459e"), new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") },
                    { new Guid("f2738636-8d31-4cfa-95de-61ca6b4f1b8a"), new DateTime(2026, 10, 1, 23, 0, 22, 9, DateTimeKind.Local).AddTicks(5236), "Bought a new fishing net from Walmart", new Guid("f66baa82-3faa-413c-943c-8690694d82ea"), new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "DestinationAccountId", "Memo", "SourceAccountId", "TransactionCategoryId", "TransactionDate", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("06441391-6b65-478d-af92-5ce1cf40e170"), 30.00m, new Guid("f6358326-9818-47a5-90c7-893519bc74b5"), "Utility bill payment", new Guid("39e1a12d-1b1c-421e-ab30-b26271958ee6"), new Guid("b5eff47d-996a-4b08-81e4-300d672e02f8"), new DateTime(2026, 10, 4, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(6960), 0, new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") },
                    { new Guid("0ce8a8b1-5d68-46c7-8665-63b3ef94cf4a"), 90.00m, new Guid("49f0e278-7dd6-4d88-928b-21595d90e2f4"), "Grocery shopping", new Guid("6cdee046-d1b6-4eb8-b558-1293bb8c1386"), new Guid("9431024f-b5c9-42d2-be6b-e5f5fbe97f19"), new DateTime(2026, 9, 30, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(6972), 0, new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") },
                    { new Guid("353c1d8e-e2f8-4acf-bfd4-880228680577"), 100.00m, new Guid("b614e031-efed-4c4a-ae98-67c31d8f57d5"), "Salary payment", new Guid("f6358326-9818-47a5-90c7-893519bc74b5"), new Guid("a293d90c-61c2-4d93-84b8-6611a8c09f75"), new DateTime(2026, 10, 1, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(6950), 1, new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") },
                    { new Guid("3fea7d0c-10f9-4c68-ac22-0af11681e7aa"), 200.00m, new Guid("6cdee046-d1b6-4eb8-b558-1293bb8c1386"), "Freelance project payment", new Guid("ef2e45f0-fa60-4664-afdc-72b2fcddd687"), new Guid("b22f78c8-6087-49db-80e6-c7fe913123c1"), new DateTime(2026, 9, 29, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(6958), 1, new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") },
                    { new Guid("47853160-a2ae-459e-9657-aa238c77e04b"), 150.00m, new Guid("b614e031-efed-4c4a-ae98-67c31d8f57d5"), "Freelance project payment", new Guid("f6358326-9818-47a5-90c7-893519bc74b5"), new Guid("b22f78c8-6087-49db-80e6-c7fe913123c1"), new DateTime(2026, 9, 28, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(6975), 1, new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") },
                    { new Guid("4b8be19d-35a9-41f5-af62-ab0f860486b1"), 60.00m, new Guid("ef2e45f0-fa60-4664-afdc-72b2fcddd687"), "Grocery shopping", new Guid("49f0e278-7dd6-4d88-928b-21595d90e2f4"), new Guid("b1c1e2e4-0c28-4c42-9eff-d1f28e009c92"), new DateTime(2026, 10, 5, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(6964), 0, new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") },
                    { new Guid("4dda9148-bd6f-441d-bba4-08a45581c8c1"), 40.00m, new Guid("39e1a12d-1b1c-421e-ab30-b26271958ee6"), "Utility bill payment", new Guid("b614e031-efed-4c4a-ae98-67c31d8f57d5"), new Guid("a293d90c-61c2-4d93-84b8-6611a8c09f75"), new DateTime(2026, 10, 2, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(6966), 0, new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") },
                    { new Guid("dc7ec32a-13de-4930-a2ed-0a930df4350f"), 25.00m, new Guid("6cdee046-d1b6-4eb8-b558-1293bb8c1386"), "Utility bill payment", new Guid("ef2e45f0-fa60-4664-afdc-72b2fcddd687"), new Guid("b5eff47d-996a-4b08-81e4-300d672e02f8"), new DateTime(2026, 9, 27, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(6978), 0, new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") },
                    { new Guid("dd2e05bc-b0fa-4aa7-89cf-ba801edff0a6"), 50.00m, new Guid("39e1a12d-1b1c-421e-ab30-b26271958ee6"), "Grocery shopping", new Guid("b614e031-efed-4c4a-ae98-67c31d8f57d5"), new Guid("b1c1e2e4-0c28-4c42-9eff-d1f28e009c92"), new DateTime(2026, 9, 26, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(6927), 0, new Guid("ccb7611a-c0b9-4b2b-8911-0ddd565c30eb") },
                    { new Guid("f9fe1bd3-4611-419e-a0b3-bdd240be822f"), 75.00m, new Guid("49f0e278-7dd6-4d88-928b-21595d90e2f4"), "Grocery shopping", new Guid("6cdee046-d1b6-4eb8-b558-1293bb8c1386"), new Guid("9431024f-b5c9-42d2-be6b-e5f5fbe97f19"), new DateTime(2026, 10, 3, 23, 0, 22, 6, DateTimeKind.Local).AddTicks(6955), 0, new Guid("311bd8fa-ccc9-47f3-8fcb-72c3762d12ad") }
                });

            migrationBuilder.InsertData(
                table: "tblJournalLine",
                columns: new[] { "Id", "AccountId", "Credit", "Debit", "JournalEntryId", "Memo" },
                values: new object[,]
                {
                    { new Guid("4d9ed5b7-4618-44a0-82d8-e1df135c1ea7"), new Guid("b614e031-efed-4c4a-ae98-67c31d8f57d5"), 0.00m, 50.00m, new Guid("ac2c3b99-7fa4-4fd6-9f82-65037674aca2"), "Grocery shopping at Amazon" },
                    { new Guid("4e64d6b1-9520-44b6-81c1-d886f9437242"), new Guid("39e1a12d-1b1c-421e-ab30-b26271958ee6"), 25.00m, 0.00m, new Guid("f2738636-8d31-4cfa-95de-61ca6b4f1b8a"), "Bought a new fishing net from Walmart" },
                    { new Guid("6186e80d-545e-436b-bef3-7f2f76ed72e7"), new Guid("b614e031-efed-4c4a-ae98-67c31d8f57d5"), 0.00m, 25.00m, new Guid("f2738636-8d31-4cfa-95de-61ca6b4f1b8a"), "Bought a new fishing net from Walmart" },
                    { new Guid("8cded07a-3cbd-4fa5-a369-678af37b0f31"), new Guid("39e1a12d-1b1c-421e-ab30-b26271958ee6"), 50.00m, 0.00m, new Guid("ac2c3b99-7fa4-4fd6-9f82-65037674aca2"), "Grocery shopping at Amazon" },
                    { new Guid("9629c442-b890-4d4a-b4be-3670e2ddd30e"), new Guid("b614e031-efed-4c4a-ae98-67c31d8f57d5"), 0.00m, 75.00m, new Guid("032bb43d-1666-48f2-a774-d3ffd333474d"), "Purchased art supplies from Target" },
                    { new Guid("b32174a0-2312-4363-a952-c2ccd1d5a1df"), new Guid("39e1a12d-1b1c-421e-ab30-b26271958ee6"), 75.00m, 0.00m, new Guid("032bb43d-1666-48f2-a774-d3ffd333474d"), "Purchased art supplies from Target" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAccount_UserId",
                table: "tblAccount",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblBudgetItem_AccountId",
                table: "tblBudgetItem",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_tblBudgetItem_BudgetId",
                table: "tblBudgetItem",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_tblBudgets_UserId",
                table: "tblBudgets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCurrencyExchange_FromCurrencyId",
                table: "tblCurrencyExchange",
                column: "FromCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCurrencyExchange_ToCurrencyId",
                table: "tblCurrencyExchange",
                column: "ToCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGoal_AccountId",
                table: "tblGoal",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGoal_MechantId",
                table: "tblGoal",
                column: "MechantId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGoal_UserId",
                table: "tblGoal",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblItem_UserId",
                table: "tblItem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblItemPrices_ItemId",
                table: "tblItemPrices",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tblItemPrices_MerchantId",
                table: "tblItemPrices",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_tblJournalEntry_MerchantId",
                table: "tblJournalEntry",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_tblJournalEntry_UserId",
                table: "tblJournalEntry",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblJournalLine_AccountId",
                table: "tblJournalLine",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_tblJournalLine_JournalEntryId",
                table: "tblJournalLine",
                column: "JournalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMerchant_UserId",
                table: "tblMerchant",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTransaction_DestinationAccountId",
                table: "tblTransaction",
                column: "DestinationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTransaction_SourceAccountId",
                table: "tblTransaction",
                column: "SourceAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTransaction_TransactionCategoryId",
                table: "tblTransaction",
                column: "TransactionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTransaction_UserId",
                table: "tblTransaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTransactionCategory_UserId",
                table: "tblTransactionCategory",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblBudgetItem");

            migrationBuilder.DropTable(
                name: "tblCurrencyExchange");

            migrationBuilder.DropTable(
                name: "tblGoal");

            migrationBuilder.DropTable(
                name: "tblItemPrices");

            migrationBuilder.DropTable(
                name: "tblJournalLine");

            migrationBuilder.DropTable(
                name: "tblTransaction");

            migrationBuilder.DropTable(
                name: "tblBudgets");

            migrationBuilder.DropTable(
                name: "tblCurrency");

            migrationBuilder.DropTable(
                name: "tblItem");

            migrationBuilder.DropTable(
                name: "tblJournalEntry");

            migrationBuilder.DropTable(
                name: "tblAccount");

            migrationBuilder.DropTable(
                name: "tblTransactionCategory");

            migrationBuilder.DropTable(
                name: "tblMerchant");

            migrationBuilder.DropTable(
                name: "tblUser");
        }
    }
}
