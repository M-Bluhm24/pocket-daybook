using Microsoft.Identity.Client;

namespace MJB.PocketDaybook.PL.Test
{
    [TestClass]
    public class utTransactionCategory : utBase<tblTransactionCategory>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 9;
            var transactions = base.LoadTest();
            Assert.AreEqual(expected, transactions.Count());
        }

        [TestMethod]
        public void UpdateTest()
        {
            var transaction = base.LoadTest().FirstOrDefault();
            transaction.Name = "Updated Transaction Category Name";
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

            var transaction = new tblTransactionCategory
            {
                UserId = userId,
                Name = "New Transaction Category Name",
                Description = "New Transaction Category Description"
            };
            int expected = 1;
            int actual = base.InsertTest(transaction);
            Assert.AreEqual(expected, actual);
        }
    }
}
