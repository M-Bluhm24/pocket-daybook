namespace MJB.PocketDaybook.PL.Test
{
    [TestClass]
    public class utBudget : utBase<tblBudget>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var budgets = base.LoadTest();
            Assert.AreEqual(expected, budgets.Count());
        }

        [TestMethod]
        public void UpdateTest()
        {
            var budget = base.LoadTest().FirstOrDefault();
            budget.Name = "Updated Budget Name";
            int expected = 1;
            int actual = base.UpdateTest(budget);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var budget = base.LoadTest().FirstOrDefault();
            int expected = 1;
            int actual = base.DeleteTest(budget);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {

            Guid userId = dc.Set<tblUser>()
                .Where(u => u.UserName == "SpongeBob")
                .Select(u => u.Id)
                .FirstOrDefault();

            var budget = new tblBudget
            {
               UserId = userId,
                Description = "New Budget Description",
                Name = "New Budget Name",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(1),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true

            };
            int expected = 1;
            int actual = base.InsertTest(budget);
            Assert.AreEqual(expected, actual);
        }

    }
}
