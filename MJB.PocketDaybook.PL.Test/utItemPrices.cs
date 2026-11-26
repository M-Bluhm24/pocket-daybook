namespace MJB.PocketDaybook.PL.Test
{
    [TestClass]
    public class utItemPrices : utBase<tblItemPrices>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 2;
            var itemPrices = base.LoadTest();
            Assert.AreEqual(expected, itemPrices.Count());
           
        }

        [TestMethod]
        public void UpdateTest()
        {
            var itemPrice = base.LoadTest().FirstOrDefault();
            itemPrice.Price = 99.99m;
            int expected = 1;
            int actual = base.UpdateTest(itemPrice);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var itemPrice = base.LoadTest().FirstOrDefault();
            int expected = 1;
            int actual = base.DeleteTest(itemPrice);
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

            Guid transactionId = dc.Set<tblTransaction>()
                .Where(u => u.UserId == userId)
                .Select(u => u.Id)
                .FirstOrDefault();

            Guid itemId = dc.Set<tblItem>()
                .Where(u => u.UserId == userId)
                .Select(u => u.Id)
                .FirstOrDefault(); 

            var itemPrice = new tblItemPrices
            {
                UserId = userId,
                MerchantId = merchantId,
                TransactionId = transactionId,
                ItemId = itemId,
                PurchaseDate = DateTime.Now,
                Price = 50.00m
            };
            int expected = 1;
            int actual = base.InsertTest(itemPrice);
            Assert.AreEqual(expected, actual);
        }

    }
}
