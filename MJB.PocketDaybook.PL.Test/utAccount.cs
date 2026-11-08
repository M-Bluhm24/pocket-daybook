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
    }
}
