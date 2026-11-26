namespace MJB.PocketDaybook.PL.Test
{
    [TestClass]
    public class utAccount : utBase<tblAccount>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 40;
            var accounts = base.LoadTest();
            Assert.AreEqual(expected, accounts.Count());
        }
        [TestMethod]
        public void UpdateTest()
        {
            var account = base.LoadTest().FirstOrDefault();
            account.Name = "Updated Account Name";
            int expected = 1;
            int actual = base.UpdateTest(account);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteTest()
        {
            var account = base.LoadTest().FirstOrDefault();
            int expected = 1;
            int actual = base.DeleteTest(account);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            Guid userId = dc.Set<tblUser>()
                .Where(u => u.UserName == "SpongeBob")
                .Select(u => u.Id)
                .FirstOrDefault();

            Console.WriteLine($"User ID: {userId}");

            var account = new tblAccount
            {
                Name = "New Account Name",
                Description = "New Account Description",
                StartingBalance = 1000.00m,
                CurrentBalance = 1000.00m,
                AccountCategory = AccountCategory.Asset,
                NormalBalance = NormalBalance.Debit,
                UserId = userId
            };
            int expected = 1;
            int actual = base.InsertTest(account);
            Assert.AreEqual(expected, actual);
        }
    }
}
