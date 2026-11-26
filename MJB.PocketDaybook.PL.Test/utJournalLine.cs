namespace MJB.PocketDaybook.PL.Test
{
    [TestClass]
    public class utJournalLine : utBase<tblJournalLine>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 20;
            var journalLines = base.LoadTest();
            Assert.AreEqual(expected, journalLines.Count());
        }

        [TestMethod]
        public void UpdateTest()
        {
            var journalLine = base.LoadTest().FirstOrDefault();
            journalLine.Credit = 999.99m;
            int expected = 1;
            int actual = base.UpdateTest(journalLine);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var journalLine = base.LoadTest().FirstOrDefault();
            int expected = 1;
            int actual = base.DeleteTest(journalLine);
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
                .Where(u => u.UserId == userId)
                .Select(u => u.Id)
                .FirstOrDefault();

            Guid journalEntryId = dc.Set<tblJournalEntry>()
                .Where(u => u.UserId == userId)
                .Select(u => u.Id)
                .FirstOrDefault();

            var journalLine = new tblJournalLine
            {
                /*Add values*/
                AccountId = accountId,
                JournalEntryId = journalEntryId,
                Debit = 100.00m,
                Credit = 0.00m,
                Memo = "Test Insert"

            };
            int expected = 1;
            int actual = base.InsertTest(journalLine);
            Assert.AreEqual(expected, actual);
        }  
    }
}
