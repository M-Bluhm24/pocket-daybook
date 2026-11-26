namespace MJB.PocketDaybook.PL.Test
{
    [TestClass]
    public class utTransaction : utBase<tblTransaction>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 10;
            var transactions = base.LoadTest();
            Assert.AreEqual(expected, transactions.Count());
        }

        [TestMethod]
        public void UpdateTest()
        {
            var transaction = base.LoadTest().FirstOrDefault();
            transaction.Amount = 999.99m;
            int expected = 1;
            int actual = base.UpdateTest(transaction);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteTest()
        {
            var transaction = base.LoadTest().FirstOrDefault();
            int expected = 1;
            int actual = base.DeleteTest(transaction);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InsertTest()
        {
            Guid userId = dc.Set<tblUser>()
                .Where(u => u.UserName == "SpongeBob")
                .Select(u => u.Id)
                .FirstOrDefault();
            
            Guid merchantId = dc.Set<tblMerchant>()
                .Where(u => u.UserId == userId)
                .Select(u => u.Id)
                .FirstOrDefault();

            Guid transactionCategoryId = dc.Set<tblTransactionCategory>()
                .Where(u => u.UserId == userId)
                .Select(u => u.Id)
                .FirstOrDefault();

            var transaction = new tblTransaction
            {
                UserId = userId,
                MerchantId = merchantId,
                TransactionCategoryId = transactionCategoryId,
                Amount = 100.00m,
                TransactionDate = DateTime.Now,
                Type = TransactionType.Expense,
                Memo = "Test Transaction"
            };
            int expected = 1;
            int actual = base.InsertTest(transaction);
            Assert.AreEqual(expected, actual);
        }
    }
}
