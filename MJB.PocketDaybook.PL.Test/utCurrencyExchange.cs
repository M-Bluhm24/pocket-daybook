namespace MJB.PocketDaybook.PL.Test
{
    [TestClass]
    public class utCurrencyExchange : utBase<tblCurrencyExchange>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var currencyExchanges = base.LoadTest();
            Assert.AreEqual(expected, currencyExchanges.Count());
        }

        [TestMethod]
        public void UpdateTest()
        {
            var currencyExchange = base.LoadTest().FirstOrDefault();
            currencyExchange.ExchangeRate = 1.5m;
            int expected = 1;
            int actual = base.UpdateTest(currencyExchange);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var currencyExchange = base.LoadTest().FirstOrDefault();
            int expected = 1;
            int actual = base.DeleteTest(currencyExchange);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {

            Guid currencyId = dc.Set<tblCurrency>()
                .Where(c => c.Name == "US Dollar")
                .Select(c => c.Id)
                .FirstOrDefault();

            var currencyExchange = new tblCurrencyExchange
            {
                /*Assign values*/

                FromCurrencyId = currencyId,
                ToCurrencyId = currencyId,
                ExchangeRate = 1.2m,
                ExchangeDate = DateTime.Now
            };
            int expected = 1;
            int actual = base.InsertTest(currencyExchange);
            Assert.AreEqual(expected, actual);
        }
    }
}
