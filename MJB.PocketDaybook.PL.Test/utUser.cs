namespace MJB.PocketDaybook.PL.Test
{
    [TestClass]
    public class utUser : utBase<tblUser>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 2;
            var users = base.LoadTest();
            Assert.AreEqual(expected, users.Count());
        }

        [TestMethod]
        public void UpdateTest()
        {
            var user = base.LoadTest().FirstOrDefault();
            user.UserName = "Updated User Name";
            int expected = 1;
            int actual = base.UpdateTest(user);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var user = base.LoadTest().FirstOrDefault();
            int expected = 1;
            int actual = base.DeleteTest(user);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            var user = new tblUser
            {
                UserName = "New User Name",
                Password = "New User Password"
            };
            int expected = 1;
            int actual = base.InsertTest(user);
            Assert.AreEqual(expected, actual);
        }
    }
}
