using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace MJB.PocketDaybook.PL.Test
{
    [TestClass]
    public class utGoal : utBase<tblGoal>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var goals = base.LoadTest();
            Assert.AreEqual(expected, goals.Count());
        }

        [TestMethod]
        public void UpdateTest()
        {
            var goal = base.LoadTest().FirstOrDefault();
            goal.Name = "Updated Goal Name";
            int expected = 1;
            int actual = base.UpdateTest(goal);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var goal = base.LoadTest().FirstOrDefault();
            int expected = 1;
            int actual = base.DeleteTest(goal);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            Guid userId = dc.Set<tblUser>()
                .Where(u => u.UserName == "SpongeBob")
                .Select(u => u.Id)
                .FirstOrDefault();
            var goal = new tblGoal
            {
                /*Assign Values*/
                UserId = userId,
                Name = "New Goal",
                Type = "Savings",
                TargetAmount = 1000.00m,
                CurrentAmount = 100.00m,
                TargetDate = DateTime.Now.AddMonths(6),
            };
            int expected = 1;
            int actual = base.InsertTest(goal);
            Assert.AreEqual(expected, actual);
        }
    }
}
