namespace MJB.PocketDaybook.PL.Test
{
    [TestClass]
    public class utMerchant : utBase<tblMerchant>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 8;
            var merchants = base.LoadTest();
            Assert.AreEqual(expected, merchants.Count());
        }

        [TestMethod]
        public void DeleteTest()
        {
            var merchant = base.LoadTest().FirstOrDefault();
            int expected = 1;
            int actual = base.DeleteTest(merchant);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            Guid userId = dc.Set<tblUser>()
                .Where(u => u.UserName == "SpongeBob")
                .Select(u => u.Id)
                .FirstOrDefault();

            var merchant = new tblMerchant
            {
                UserId = userId,
                Name = "Test Merchant",
                Description = "Test Merchant Description",
                Website = "https://www.testmerchant.com"
            };
            int expected = 1;
            int actual = base.InsertTest(merchant);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateTest()
        {
            var merchant = base.LoadTest().FirstOrDefault();
            merchant.Name = "Updated Merchant Name";
            int expected = 1;
            int actual = base.UpdateTest(merchant);
            Assert.AreEqual(expected, actual);
        }
    }
}
