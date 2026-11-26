namespace MJB.PocketDaybook.PL.Test
{
    [TestClass]
    public class utItem : utBase<tblItem>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 10;
            var items = base.LoadTest();
            Assert.AreEqual(expected, items.Count());
        }

        [TestMethod]
        public void UpdateTest()
        {
            var item = base.LoadTest().FirstOrDefault();
            item.Name = "Updated Item";
            int expected = 1;
            int actual = base.UpdateTest(item);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var item = base.LoadTest().FirstOrDefault();
            int expected = 1;
            int actual = base.DeleteTest(item);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            Guid userId = dc.Set<tblUser>()
                .Where(u => u.UserName == "SpongeBob")
                .Select(u => u.Id)
                .FirstOrDefault();

            var item = new tblItem
            {
                UserId = userId,
                Name = "New Item",
                Description = "This is a new item."
            };
            int expected = 1;
            int actual = base.InsertTest(item);
            Assert.AreEqual(expected, actual);
        }
    }
}
