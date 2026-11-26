namespace MJB.PocketDaybook.PL.Test
{
    [TestClass]
    public class utJournalEntry : utBase<tblJournalEntry>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 10;
            var journalEntries = base.LoadTest();
            Assert.AreEqual(expected, journalEntries.Count());
        }

        [TestMethod]
        public void UpdateTest()
        {
            var journalEntry = base.LoadTest().FirstOrDefault();
            journalEntry.Memo = "Updated Entry Text";
            int expected = 1;
            int actual = base.UpdateTest(journalEntry);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var journalEntry = base.LoadTest().FirstOrDefault();
            int expected = 1;
            int actual = base.DeleteTest(journalEntry);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            Guid userId = dc.Set<tblUser>()
                .Where(u => u.UserName == "SpongeBob")
                .Select(u => u.Id)
                .FirstOrDefault();

            var journalEntry = new tblJournalEntry
            {
                UserId = userId,
                Memo = "New Entry Text",
                EntryDate = DateTime.Now
            };
            int expected = 1;
            int actual = base.InsertTest(journalEntry);
            Assert.AreEqual(expected, actual);
        }
    }
}
