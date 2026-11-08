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
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    MerchantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_tblTransaction_tblMerchant_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "tblMerchant",
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

            migrationBuilder.CreateTable(
                name: "tblItemPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MerchantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblItemPrices_tblMerchant_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "tblMerchant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblItemPrices_tblTransaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "tblTransaction",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblItemPrices_tblUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "tblCurrency",
                columns: new[] { "Id", "Code", "DecimalPlaces", "Name", "Symbol" },
                values: new object[,]
                {
                    { new Guid("45808775-cf03-41d1-9a2d-e5b13f116d00"), "USD", 2, "US Dollar", "$" },
                    { new Guid("d1abd229-2ff7-427c-b684-129a4e9c7f27"), "EUR", 2, "Euro", "€" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("b14efd12-e5cf-4922-819a-c7b230aed394"), "v4wQdj5KSOuUfqw0k/69BP/Veu4VcQ2qi29rTwkfQa8=", "Squidward" },
                    { new Guid("d81c3320-5d37-4457-81a5-00d8447820ee"), "Id/BjdBM1qNW4vHjboKFvAYKXVidOscH5WrJZUkDtYk=", "SpongeBob" }
                });

            migrationBuilder.InsertData(
                table: "tblAccount",
                columns: new[] { "Id", "AccountCategory", "CurrentBalance", "Description", "Name", "NormalBalance", "StartingBalance", "UserId" },
                values: new object[,]
                {
                    { new Guid("0a3be747-92cd-449f-8eef-914d5a68bd49"), 5, 100m, "Spongebob electricity account", "Electricity", 1, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("0c824732-9114-467a-ae17-a970a2915347"), 5, 100m, "Spongebob internet account", "Internet", 1, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("1afcee89-992e-4e74-bf8c-242b0c783601"), 1, 11055m, "Spongebob cash account", "Cash", 1, 10020m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("1e85add8-31b0-4771-935d-c34119ceeb12"), 4, 0m, "Spongebob dividend account", "Dividend", 2, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("1f1bd44b-07ea-4bde-98a4-773779b23e0b"), 5, 0m, "Squidward rent account", "Rent", 1, 0m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("2062fa35-75ff-4ff9-a74b-ef04762e8545"), 1, 4050m, "Squidward cash account", "Cash", 1, 5000m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("28d7063c-ebfa-4d08-91f3-40bb1e5e29f9"), 4, 0m, "Spongebob secondary income account", "Secondary Income", 2, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("3d54fa4b-a83f-4139-a64f-077ebe18c9a4"), 3, 0m, "Squidward net worth account", "Net Worth", 2, -45000m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("5bbd0eda-019d-4728-b2c1-65301b443dfd"), 2, 0m, "Spongebob loan account", "Loan", 2, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("5da5fca8-75ce-4e29-a7cb-afcf0f72c497"), 4, 1000m, "Squidward income account", "Income", 2, 0m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("5fed347c-47bc-410f-a1e2-9c3c6d8df53b"), 5, 150m, "Squidward electricity account", "Electricity", 1, 0m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("654819e8-5390-493e-b662-707ecaf1eaae"), 1, 0m, "Spongebob checking account", "Checking", 1, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("6f80c9a4-79c7-492a-b019-80b46ceb1978"), 1, 0m, "Spongebob savings account", "Savings", 1, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("722b344a-9f93-4289-8596-29826510cdc5"), 2, 0m, "Squidward credit card account", "Credit card", 2, 0m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("7fdf2bd1-84ef-4f26-a56f-b5b70ae424ec"), 5, 100m, "Squidward internet account", "Internet", 1, 0m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("848104fe-257f-43a3-9a68-5ad89db2e494"), 4, 1500m, "Spongebob income account", "Income", 2, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("91e62639-9013-415c-b303-c2f3439a2c23"), 5, 0m, "Spongebob phone account", "Phone", 1, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("9433ce2a-85c5-4238-98a1-9fba972326d9"), 4, 0m, "Squidward dividend account", "Dividend", 2, 0m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("97c384ad-5d0b-4f44-9ec1-24ae81cff87f"), 2, 0m, "Spongebob credit card account", "Credit card", 2, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("9ae54615-87d8-49e7-a39b-5345cebd4b70"), 1, 0m, "Squidward brokerage account", "Brokerage", 1, 0m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("a173a2c4-afb0-43fa-a45c-e525e295b279"), 2, 24750m, "Spongebob morgage account", "Morgage", 2, 25000m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("a40eab67-f348-425b-827c-bc1d70ba9814"), 4, 0m, "Squidward interest account", "Interest", 2, 0m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("a415fc98-4696-4647-a03d-f767fcee7616"), 4, 0m, "Spongebob interest account", "Interest", 2, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("b522f4a2-aac9-4fdf-9d6b-363fd64fb479"), 1, 0m, "Squidward checking account", "Checking", 1, 0m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("b586aad5-9d3e-4416-9f7d-2890b74924ba"), 5, 15m, "Spongebob groceries account", "Groceries", 1, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("bab8dd6a-4395-4cfa-8b99-56e761df9438"), 5, 0m, "Spongebob rent account", "Rent", 1, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("bceac8c2-5c61-4703-9cd2-05ac6dda7c21"), 4, 0m, "Squidward secondary income account", "Secondary Income", 2, 0m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("be873ecf-b48f-421b-b92c-5f063352e493"), 1, 0m, "Squidward property account", "Property", 1, 0m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("c01eb97a-187f-4a25-8e7c-e14d387a85c4"), 2, 49900m, "Squidward morgage account", "Morgage", 2, 50000m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("c1520c6e-56d7-4a32-84fa-fa4feeb49944"), 1, 0m, "Spongebob property account", "Property", 1, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("c1bec398-c332-4fa2-beb1-a09523a40385"), 3, -14980m, "Spongebob net worth account", "Net Worth", 2, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("c32cb409-8066-46fc-b109-b1d116438af3"), 5, 1500m, "Squidward groceries account", "Groceries", 1, 0m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("cd3a932b-063e-4c99-99c3-526969f59fe9"), 1, 0m, "Squidward retirement account", "Retirement", 1, 0m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("d526d2ab-828e-48a6-9d2c-5f948b8d9034"), 5, 0m, "Squidward taxes account", "Taxes", 1, 0m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("e215c095-a5fc-49c3-be67-cc993d50f5dc"), 1, 0m, "Squidward savings account", "Savings", 1, 0m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("e3a463c8-b6e0-4e14-a0b3-da1da80e0c46"), 5, 0m, "Squidward phone account", "Phone", 1, 0m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("e4d8f613-4436-46ea-9b1a-8009944495d3"), 2, 0m, "Squidward loan account", "Loan", 2, 0m, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("e6ea908f-2485-483d-bcd8-a2e111adaea5"), 5, 0m, "Spongebob taxes account", "Taxes", 1, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("ebd6656b-8ea5-4db2-b29f-cb740c663c34"), 1, 0m, "Spongebob retirement account", "Retirement", 1, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("ef1f2fec-5c84-4e76-bb71-da7997610673"), 1, 0m, "Spongebob brokerage account", "Brokerage", 1, 0m, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") }
                });

            migrationBuilder.InsertData(
                table: "tblBudgets",
                columns: new[] { "Id", "CreatedAt", "Description", "EndDate", "IsActive", "Name", "StartDate", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("487bf0e0-eeaa-4434-a3e8-7c40947c1a66"), new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1119), "Budget for the upcoming vacation", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Vacation Budget", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1120), new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("5fabf2b0-9a72-498b-806b-53d9a69a9592"), new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1114), "Spongebob budget for the month of June", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Monthly Budget", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1116), new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("a923920a-6994-49c2-99ba-663af7c44a3f"), new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1122), "Squidward budget for the month of June", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Monthly Budget", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1123), new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") }
                });

            migrationBuilder.InsertData(
                table: "tblCurrencyExchange",
                columns: new[] { "Id", "ExchangeDate", "ExchangeRate", "FromCurrencyId", "ToCurrencyId" },
                values: new object[,]
                {
                    { new Guid("64d33766-e333-4fe6-8a9d-cdbb1521b7bb"), new DateTime(2026, 10, 29, 15, 25, 7, 61, DateTimeKind.Local).AddTicks(8106), 0.85m, new Guid("45808775-cf03-41d1-9a2d-e5b13f116d00"), new Guid("d1abd229-2ff7-427c-b684-129a4e9c7f27") },
                    { new Guid("bae0a383-3fe5-4eb5-857a-9c58dd4bf3c4"), new DateTime(2026, 11, 3, 15, 25, 7, 61, DateTimeKind.Local).AddTicks(8123), 1.18m, new Guid("d1abd229-2ff7-427c-b684-129a4e9c7f27"), new Guid("45808775-cf03-41d1-9a2d-e5b13f116d00") },
                    { new Guid("c30fbd29-05d1-41a3-b225-9af58d5c6558"), new DateTime(2026, 11, 5, 15, 25, 7, 61, DateTimeKind.Local).AddTicks(8126), 0.84m, new Guid("45808775-cf03-41d1-9a2d-e5b13f116d00"), new Guid("d1abd229-2ff7-427c-b684-129a4e9c7f27") }
                });

            migrationBuilder.InsertData(
                table: "tblItem",
                columns: new[] { "Id", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("0dec4a85-843a-4f3d-9f35-cd8d8fc50ae7"), "24-Slices", "Cheese", new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("4103d275-0ac1-4c02-9ea4-79b648cc98e8"), "C# Clairy 5000", "Clarinet", new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("50715ab3-31c4-41db-8ed2-eaf6e9702ba2"), "1 Rock", "Rocks", new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("50adb529-1187-4980-b18d-a496cae471db"), "12-Oz Blue", "Art Paint", new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("50d05204-327d-4de1-8552-a42156d40f12"), "500-Pack", "Napkins", new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("85f8709f-5385-44f8-849d-c0b5b1dd78ee"), "24-Slices", "Cheese", new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("8b170c7b-3ba4-4cc8-9aa8-630663efb880"), "12-Pack", "Buns", new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("9d731340-689a-4702-a1ac-d7a3818dfc66"), "10 Gallons", "Gas", new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("afc35edc-cae7-437b-835e-e47d36e771b5"), "100-Pounds", "Snail Food", new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("b86789ef-1c26-4b8c-874c-c3f637fe1411"), "Replacement", "Fishing Net", new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") }
                });

            migrationBuilder.InsertData(
                table: "tblMerchant",
                columns: new[] { "Id", "Description", "Name", "UserId", "Website" },
                values: new object[,]
                {
                    { new Guid("0b4fe1bb-775d-478f-9e76-9016fb00f1a5"), "Restaurant", "Krusty Krab", new Guid("d81c3320-5d37-4457-81a5-00d8447820ee"), "none" },
                    { new Guid("1445a199-8381-4bd7-990a-69b2499aa905"), "Banking and Morgage", "First National Bank of Bikini Bottom", new Guid("d81c3320-5d37-4457-81a5-00d8447820ee"), "none" },
                    { new Guid("5a45da2b-cc61-4a42-8a05-13e02605b453"), "Power and Internet", "Bikini Bottom Power and Communications", new Guid("b14efd12-e5cf-4922-819a-c7b230aed394"), "none" },
                    { new Guid("61bdcfea-bdbc-4e6e-9c4d-22513e3f19b2"), "Restaurant", "Krusty Krab", new Guid("b14efd12-e5cf-4922-819a-c7b230aed394"), "none" },
                    { new Guid("669aea9b-4ae6-4a3e-8ce0-24f5f5e0a454"), "Retail Store", "Quicky Mart", new Guid("d81c3320-5d37-4457-81a5-00d8447820ee"), "none" },
                    { new Guid("8b99f0a8-1a2b-47b8-b0a2-2fd943117cc5"), "Banking and Mortgage", "First National Bank of Bikini Bottom", new Guid("b14efd12-e5cf-4922-819a-c7b230aed394"), "none" },
                    { new Guid("db34b395-6078-468e-953f-8286da28c59c"), "Retail Store", "Quicky Mart", new Guid("b14efd12-e5cf-4922-819a-c7b230aed394"), "none" },
                    { new Guid("f27644d1-6451-4999-8487-b0541d6c9955"), "Power and Internet", "Bikini Bottom Power and Communications", new Guid("d81c3320-5d37-4457-81a5-00d8447820ee"), "none" }
                });

            migrationBuilder.InsertData(
                table: "tblTransactionCategory",
                columns: new[] { "Id", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("37276b94-b14a-40f3-a44b-0563122882a2"), "Food and household items", "Groceries", new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("3ad1fa92-91d1-4f17-8eb3-d16b5bbe643b"), "Rent and bills", "Utilities", new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("4700cc83-68fa-45dd-9cc4-4b5a4a71552c"), "Morgage, rent, upkeep", "Housing", new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("63a4c377-f628-41b5-9f1c-f3568956fb82"), "Money from various sources", "Income", new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("7543548e-7f33-4b88-b29c-36d53452387c"), "Morgage, rent, upkeep", "Housing", new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("98755b6f-b2d6-4842-b472-9d451a8fc60b"), "Gas, public transit, etc.", "Transportation", new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("e6ac526e-c7ef-4398-a68a-9ed8a2d68f2c"), "Money from various sources", "Income", new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("ea47c947-79de-4699-8c10-1c27ac680244"), "Electricity, water, gas, etc.", "Utilities", new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("f7a5d296-c957-47c4-b38f-8bfc1e45844e"), "My food for the month", "Groceries", new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") }
                });

            migrationBuilder.InsertData(
                table: "tblBudgetItem",
                columns: new[] { "Id", "AccountId", "Amount", "BudgetId", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("55f4e158-b7de-4aba-859c-589faa2048a4"), new Guid("1afcee89-992e-4e74-bf8c-242b0c783601"), 1200.00m, new Guid("5fabf2b0-9a72-498b-806b-53d9a69a9592"), new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1746), "Monthly rent payment", "Rent", new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1749) },
                    { new Guid("55f87152-4f13-481f-91ef-debed9924c1a"), new Guid("1afcee89-992e-4e74-bf8c-242b0c783601"), 800.00m, new Guid("487bf0e0-eeaa-4434-a3e8-7c40947c1a66"), new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1758), "Hotel accommodation for vacation", "Hotel", new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1759) },
                    { new Guid("7001c624-e6dd-44ff-8433-d59520fd6ba1"), new Guid("654819e8-5390-493e-b662-707ecaf1eaae"), 250.00m, new Guid("a923920a-6994-49c2-99ba-663af7c44a3f"), new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1765), "Monthly groceries", "Groceries", new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1765) },
                    { new Guid("b308c892-1c56-46b8-b572-6fb11211d0a0"), new Guid("1afcee89-992e-4e74-bf8c-242b0c783601"), 500.00m, new Guid("487bf0e0-eeaa-4434-a3e8-7c40947c1a66"), new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1756), "Flight tickets for vacation", "Flight", new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1756) },
                    { new Guid("d77ce1e2-4bc7-4c9e-bc2b-2f4185b22863"), new Guid("1afcee89-992e-4e74-bf8c-242b0c783601"), 300.00m, new Guid("5fabf2b0-9a72-498b-806b-53d9a69a9592"), new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1753), "Monthly groceries", "Groceries", new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1753) },
                    { new Guid("f1a38e5e-c83b-45ef-b3cc-a5b7d74aa195"), new Guid("654819e8-5390-493e-b662-707ecaf1eaae"), 1000.00m, new Guid("a923920a-6994-49c2-99ba-663af7c44a3f"), new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1761), "Monthly rent payment", "Rent", new DateTime(2026, 11, 8, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(1762) }
                });

            migrationBuilder.InsertData(
                table: "tblGoal",
                columns: new[] { "Id", "AccountId", "CurrentAmount", "MechantId", "Name", "TargetAmount", "TargetDate", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("61e6e774-14bd-4a77-817c-e5e1f2c39c3e"), new Guid("654819e8-5390-493e-b662-707ecaf1eaae"), 1500.00m, new Guid("1445a199-8381-4bd7-990a-69b2499aa905"), "Vacation Fund", 5000.00m, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Savings", new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("641eb589-f280-4ef5-a743-48f5a415aec7"), new Guid("ebd6656b-8ea5-4db2-b29f-cb740c663c34"), 800.00m, new Guid("669aea9b-4ae6-4a3e-8ce0-24f5f5e0a454"), "Emergency Fund", 3000.00m, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Savings", new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("dbb5e8c5-66f3-409c-aa25-56804ff27a87"), new Guid("1afcee89-992e-4e74-bf8c-242b0c783601"), 2500.00m, new Guid("f27644d1-6451-4999-8487-b0541d6c9955"), "Buy a Car", 10000.00m, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Savings", new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") }
                });

            migrationBuilder.InsertData(
                table: "tblJournalEntry",
                columns: new[] { "Id", "EntryDate", "Memo", "MerchantId", "UserId" },
                values: new object[,]
                {
                    { new Guid("29e3d13f-680d-4b47-9eeb-8455e82a8be1"), new DateTime(2026, 11, 1, 15, 25, 7, 60, DateTimeKind.Local).AddTicks(6690), "Groceries", new Guid("669aea9b-4ae6-4a3e-8ce0-24f5f5e0a454"), new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("653dc786-8c1c-4aa1-9836-159f6e75a859"), new DateTime(2026, 10, 29, 15, 25, 7, 60, DateTimeKind.Local).AddTicks(6665), "Payday", new Guid("0b4fe1bb-775d-478f-9e76-9016fb00f1a5"), new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("69abee26-1c4e-4dea-a417-2503ef92374d"), new DateTime(2026, 11, 7, 15, 25, 7, 60, DateTimeKind.Local).AddTicks(6695), "Payday", new Guid("61bdcfea-bdbc-4e6e-9c4d-22513e3f19b2"), new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("98a6fb49-2445-46cf-ba45-2304d4e7a4d4"), new DateTime(2026, 11, 4, 15, 25, 7, 60, DateTimeKind.Local).AddTicks(6697), "Power Payment", new Guid("5a45da2b-cc61-4a42-8a05-13e02605b453"), new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("c2f28edb-bc4e-4bae-8c2e-c2dc02a06795"), new DateTime(2026, 11, 2, 15, 25, 7, 60, DateTimeKind.Local).AddTicks(6699), "Morgage Payment", new Guid("8b99f0a8-1a2b-47b8-b0a2-2fd943117cc5"), new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("da721c7c-bbbc-45d1-913c-fffb887dcf9e"), new DateTime(2026, 10, 30, 15, 25, 7, 60, DateTimeKind.Local).AddTicks(6704), "Internet Payment", new Guid("5a45da2b-cc61-4a42-8a05-13e02605b453"), new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("dbf73d12-3ab8-47b5-8fe0-e6d7fbdb8ea3"), new DateTime(2026, 11, 3, 15, 25, 7, 60, DateTimeKind.Local).AddTicks(6686), "Power Payment", new Guid("f27644d1-6451-4999-8487-b0541d6c9955"), new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("e5e6874f-ebfc-4924-b69f-37833f877a6b"), new DateTime(2026, 11, 5, 15, 25, 7, 60, DateTimeKind.Local).AddTicks(6688), "Morgage Payment", new Guid("1445a199-8381-4bd7-990a-69b2499aa905"), new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("e997100b-cc02-47e9-a90e-29308113827c"), new DateTime(2026, 11, 6, 15, 25, 7, 60, DateTimeKind.Local).AddTicks(6692), "Internet Payment", new Guid("f27644d1-6451-4999-8487-b0541d6c9955"), new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("f1ffdee8-ef64-48cc-b30e-a38221a22d14"), new DateTime(2026, 10, 31, 15, 25, 7, 60, DateTimeKind.Local).AddTicks(6701), "Groceries", new Guid("db34b395-6078-468e-953f-8286da28c59c"), new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") }
                });

            migrationBuilder.InsertData(
                table: "tblTransaction",
                columns: new[] { "Id", "Amount", "Memo", "MerchantId", "TransactionCategoryId", "TransactionDate", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("04edbbbb-044c-48d5-a0da-4b4e3788c44e"), 100.00m, "Internet Payment", new Guid("5a45da2b-cc61-4a42-8a05-13e02605b453"), new Guid("3ad1fa92-91d1-4f17-8eb3-d16b5bbe643b"), new DateTime(2026, 10, 30, 15, 25, 7, 57, DateTimeKind.Local).AddTicks(9859), 0, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("2ee64f30-7844-4df2-8e2b-7e649dca74c3"), 100.00m, "Power Payment", new Guid("f27644d1-6451-4999-8487-b0541d6c9955"), new Guid("ea47c947-79de-4699-8c10-1c27ac680244"), new DateTime(2026, 11, 3, 15, 25, 7, 57, DateTimeKind.Local).AddTicks(9838), 1, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("6226f569-7679-4d9e-ac50-723a2c0dae8b"), 150.00m, "Power Payment", new Guid("5a45da2b-cc61-4a42-8a05-13e02605b453"), new Guid("3ad1fa92-91d1-4f17-8eb3-d16b5bbe643b"), new DateTime(2026, 11, 4, 15, 25, 7, 57, DateTimeKind.Local).AddTicks(9852), 0, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("6cb5b336-fc17-4442-9bc7-2e701ffeffda"), 100.00m, "Morgage Payment", new Guid("8b99f0a8-1a2b-47b8-b0a2-2fd943117cc5"), new Guid("7543548e-7f33-4b88-b29c-36d53452387c"), new DateTime(2026, 11, 2, 15, 25, 7, 57, DateTimeKind.Local).AddTicks(9854), 0, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("8670c30b-123e-4f08-8a8a-21bb20e126bf"), 15.00m, "Groceries", new Guid("669aea9b-4ae6-4a3e-8ce0-24f5f5e0a454"), new Guid("37276b94-b14a-40f3-a44b-0563122882a2"), new DateTime(2026, 11, 1, 15, 25, 7, 57, DateTimeKind.Local).AddTicks(9843), 1, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("9fc043be-7579-4bdb-9b8c-b1113ddc235e"), 100.00m, "Internet Payment", new Guid("f27644d1-6451-4999-8487-b0541d6c9955"), new Guid("ea47c947-79de-4699-8c10-1c27ac680244"), new DateTime(2026, 11, 6, 15, 25, 7, 57, DateTimeKind.Local).AddTicks(9846), 0, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("b470e93a-f19c-47d8-b842-df2b67a2efba"), 250.00m, "Morgage Payment", new Guid("1445a199-8381-4bd7-990a-69b2499aa905"), new Guid("4700cc83-68fa-45dd-9cc4-4b5a4a71552c"), new DateTime(2026, 11, 5, 15, 25, 7, 57, DateTimeKind.Local).AddTicks(9841), 0, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") },
                    { new Guid("f90cfaac-db4a-4a32-9349-a97700db5b47"), 1000.00m, "Income", new Guid("61bdcfea-bdbc-4e6e-9c4d-22513e3f19b2"), new Guid("63a4c377-f628-41b5-9f1c-f3568956fb82"), new DateTime(2026, 11, 7, 15, 25, 7, 57, DateTimeKind.Local).AddTicks(9849), 0, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("fe45cd2d-4327-4af4-b7fb-4bee5d052c10"), 1500.00m, "Groceries", new Guid("db34b395-6078-468e-953f-8286da28c59c"), new Guid("ea47c947-79de-4699-8c10-1c27ac680244"), new DateTime(2026, 10, 31, 15, 25, 7, 57, DateTimeKind.Local).AddTicks(9856), 1, new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("ff7a14e0-4965-4766-b402-b149146fa6e6"), 1500.00m, "Income", new Guid("0b4fe1bb-775d-478f-9e76-9016fb00f1a5"), new Guid("e6ac526e-c7ef-4398-a68a-9ed8a2d68f2c"), new DateTime(2026, 10, 29, 15, 25, 7, 57, DateTimeKind.Local).AddTicks(9791), 0, new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") }
                });

            migrationBuilder.InsertData(
                table: "tblItemPrices",
                columns: new[] { "Id", "ItemId", "MerchantId", "Price", "PurchaseDate", "TransactionId", "UserId" },
                values: new object[,]
                {
                    { new Guid("612bff92-8abe-4dfe-a95f-12ad88ec1716"), new Guid("4103d275-0ac1-4c02-9ea4-79b648cc98e8"), new Guid("db34b395-6078-468e-953f-8286da28c59c"), 1500.00m, new DateTime(2026, 10, 31, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(675), new Guid("fe45cd2d-4327-4af4-b7fb-4bee5d052c10"), new Guid("b14efd12-e5cf-4922-819a-c7b230aed394") },
                    { new Guid("b50dadc6-79ab-4edd-8a63-a8a0ea393ff7"), new Guid("85f8709f-5385-44f8-849d-c0b5b1dd78ee"), new Guid("669aea9b-4ae6-4a3e-8ce0-24f5f5e0a454"), 15.00m, new DateTime(2026, 11, 1, 15, 25, 7, 58, DateTimeKind.Local).AddTicks(669), new Guid("8670c30b-123e-4f08-8a8a-21bb20e126bf"), new Guid("d81c3320-5d37-4457-81a5-00d8447820ee") }
                });

            migrationBuilder.InsertData(
                table: "tblJournalLine",
                columns: new[] { "Id", "AccountId", "Credit", "Debit", "JournalEntryId", "Memo" },
                values: new object[,]
                {
                    { new Guid("099b5c7f-1374-4dc0-bdec-f0b5a7e9a0f2"), new Guid("b586aad5-9d3e-4416-9f7d-2890b74924ba"), 0.00m, 15.00m, new Guid("29e3d13f-680d-4b47-9eeb-8455e82a8be1"), "Groceries" },
                    { new Guid("0e2365df-31f4-4fcb-864f-f57aa270fd5a"), new Guid("2062fa35-75ff-4ff9-a74b-ef04762e8545"), 0.00m, 1000.00m, new Guid("69abee26-1c4e-4dea-a417-2503ef92374d"), "Income" },
                    { new Guid("0eef01d1-916f-42b6-a69a-19fda8e88130"), new Guid("c01eb97a-187f-4a25-8e7c-e14d387a85c4"), 0.00m, 100.00m, new Guid("c2f28edb-bc4e-4bae-8c2e-c2dc02a06795"), "Morgage Payment" },
                    { new Guid("14238403-f7de-4848-bfc5-664fdea0c062"), new Guid("c32cb409-8066-46fc-b109-b1d116438af3"), 0.00m, 1500.00m, new Guid("f1ffdee8-ef64-48cc-b30e-a38221a22d14"), "Groceries" },
                    { new Guid("18c7173d-f7ba-470e-9897-7cb94c157589"), new Guid("7fdf2bd1-84ef-4f26-a56f-b5b70ae424ec"), 0.00m, 100.00m, new Guid("da721c7c-bbbc-45d1-913c-fffb887dcf9e"), "Internet Payment" },
                    { new Guid("5195fb08-809f-4509-9998-c309eafc0919"), new Guid("0a3be747-92cd-449f-8eef-914d5a68bd49"), 0.00m, 100.00m, new Guid("dbf73d12-3ab8-47b5-8fe0-e6d7fbdb8ea3"), "Power Payment" },
                    { new Guid("6e26359e-d211-4e43-a85d-4ba75905795d"), new Guid("0c824732-9114-467a-ae17-a970a2915347"), 0.00m, 100.00m, new Guid("e997100b-cc02-47e9-a90e-29308113827c"), "Internet Payment" },
                    { new Guid("8055ff93-6358-4698-b62e-27a3486baf4a"), new Guid("2062fa35-75ff-4ff9-a74b-ef04762e8545"), 100.00m, 0.00m, new Guid("c2f28edb-bc4e-4bae-8c2e-c2dc02a06795"), "Morgage Payment" },
                    { new Guid("80952bba-395d-4759-bd1c-55bc24b4cc90"), new Guid("5fed347c-47bc-410f-a1e2-9c3c6d8df53b"), 0.00m, 150.00m, new Guid("98a6fb49-2445-46cf-ba45-2304d4e7a4d4"), "Power Payment" },
                    { new Guid("813ff8d0-d55d-44a7-b84e-1b85c5f60219"), new Guid("1afcee89-992e-4e74-bf8c-242b0c783601"), 15.00m, 0.00m, new Guid("29e3d13f-680d-4b47-9eeb-8455e82a8be1"), "Groceries" },
                    { new Guid("93a3f136-636e-4553-98e2-2aba3e8175fa"), new Guid("1afcee89-992e-4e74-bf8c-242b0c783601"), 0.00m, 1500.00m, new Guid("653dc786-8c1c-4aa1-9836-159f6e75a859"), "Income" },
                    { new Guid("bc5f31ae-0606-4d94-a6a9-838e181a76ad"), new Guid("1afcee89-992e-4e74-bf8c-242b0c783601"), 250.00m, 0.00m, new Guid("e5e6874f-ebfc-4924-b69f-37833f877a6b"), "Morgage Payment" },
                    { new Guid("bd170bc6-b243-44ce-b388-5cdaf7c6ff81"), new Guid("a173a2c4-afb0-43fa-a45c-e525e295b279"), 0.00m, 250.00m, new Guid("e5e6874f-ebfc-4924-b69f-37833f877a6b"), "Morgage Payment" },
                    { new Guid("c1402771-906a-4f58-8439-6dc155194f58"), new Guid("2062fa35-75ff-4ff9-a74b-ef04762e8545"), 150.00m, 0.00m, new Guid("98a6fb49-2445-46cf-ba45-2304d4e7a4d4"), "Power Payment" },
                    { new Guid("cd9b9f43-a5bd-4c7b-8cd9-f0d6af148e95"), new Guid("2062fa35-75ff-4ff9-a74b-ef04762e8545"), 100.00m, 0.00m, new Guid("da721c7c-bbbc-45d1-913c-fffb887dcf9e"), "Internet Payment" },
                    { new Guid("e24f26d0-84fb-41e7-9ddc-531fc8226b9c"), new Guid("2062fa35-75ff-4ff9-a74b-ef04762e8545"), 1500.00m, 0.00m, new Guid("f1ffdee8-ef64-48cc-b30e-a38221a22d14"), "Groceries" },
                    { new Guid("ee117914-2f93-4bdf-9717-ad5e096e9222"), new Guid("1afcee89-992e-4e74-bf8c-242b0c783601"), 100.00m, 0.00m, new Guid("e997100b-cc02-47e9-a90e-29308113827c"), "Internet Payment" },
                    { new Guid("ee3e47a3-b02a-495f-b724-4a49efa5958e"), new Guid("848104fe-257f-43a3-9a68-5ad89db2e494"), 1500.00m, 0.00m, new Guid("653dc786-8c1c-4aa1-9836-159f6e75a859"), "Income" },
                    { new Guid("f36ded0a-701b-4e76-ab57-a6f10ff86d0b"), new Guid("5da5fca8-75ce-4e29-a7cb-afcf0f72c497"), 1000.00m, 0.00m, new Guid("69abee26-1c4e-4dea-a417-2503ef92374d"), "Income" },
                    { new Guid("fc169a0f-66da-4fa0-9afa-5b085441acd1"), new Guid("1afcee89-992e-4e74-bf8c-242b0c783601"), 100.00m, 0.00m, new Guid("dbf73d12-3ab8-47b5-8fe0-e6d7fbdb8ea3"), "Power Payment" }
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
                name: "IX_tblItemPrices_TransactionId",
                table: "tblItemPrices",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblItemPrices_UserId",
                table: "tblItemPrices",
                column: "UserId");

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
                name: "IX_tblTransaction_MerchantId",
                table: "tblTransaction",
                column: "MerchantId");

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
                name: "tblBudgets");

            migrationBuilder.DropTable(
                name: "tblCurrency");

            migrationBuilder.DropTable(
                name: "tblItem");

            migrationBuilder.DropTable(
                name: "tblTransaction");

            migrationBuilder.DropTable(
                name: "tblAccount");

            migrationBuilder.DropTable(
                name: "tblJournalEntry");

            migrationBuilder.DropTable(
                name: "tblTransactionCategory");

            migrationBuilder.DropTable(
                name: "tblMerchant");

            migrationBuilder.DropTable(
                name: "tblUser");
        }
    }
}
