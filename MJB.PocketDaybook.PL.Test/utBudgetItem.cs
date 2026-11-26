namespace MJB.PocketDaybook.PL.Test
{
    [TestClass]
    public class utBudgetItem : utBase<tblBudgetItem>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 6;
            var budgetItems = base.LoadTest();
            Assert.AreEqual(expected, budgetItems.Count());
        }

        [TestMethod]
        public void UpdateTest()
        {
            var budgetItem = base.LoadTest().FirstOrDefault();
            budgetItem.Name = "Updated Budget Item Name";
            int expected = 1;
            int actual = base.UpdateTest(budgetItem);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var budgetItem = base.LoadTest().FirstOrDefault();
            int expected = 1;
            int actual = base.DeleteTest(budgetItem);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            Guid userId = dc.Set<tblUser>()
                .Where(u => u.UserName == "SpongeBob")
                .Select(u => u.Id)
                .FirstOrDefault();

            Guid accountId = dc.Set<tblAccount>()
                .Where(a => a.UserId == userId)
                .Select(a => a.Id)
                .FirstOrDefault();

            Guid budgetId = dc.Set<tblBudget>()
                .Where(b => b.UserId == userId)
                .Select(b => b.Id)
                .FirstOrDefault();

            var budgetItem = new tblBudgetItem
            {
                BudgetId = budgetId,
                AccountId = accountId,
                Name = "New Budget Item Name",
                Description = "New Budget Item Description",
                Amount = 500.00m,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            int expected = 1;
            int actual = base.InsertTest(budgetItem);
            Assert.AreEqual(expected, actual);
        }
    }
}
