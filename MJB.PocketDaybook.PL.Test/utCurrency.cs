namespace MJB.PocketDaybook.PL.Test
{
    [TestClass]
    public class utCurrency : utBase<tblCurrency>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 2;
            var currencies = base.LoadTest();
            Assert.AreEqual(expected, currencies.Count());
        }

        [TestMethod]
        public void UpdateTest()
        {
            var currency = base.LoadTest().FirstOrDefault();
            currency.Name = "Updated Currency Name";
            int expected = 1;
            int actual = base.UpdateTest(currency);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var currency = base.LoadTest().FirstOrDefault();
            int expected = 1;
            int actual = base.DeleteTest(currency);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            var currency = new tblCurrency
            {
               
                Name = "New Currency Name",
                Symbol = "$",
                Code = "NCN",
                DecimalPlaces = 2
            };
            int expected = 1;
            int actual = base.InsertTest(currency);
            Assert.AreEqual(expected, actual);
        }
    }
}
