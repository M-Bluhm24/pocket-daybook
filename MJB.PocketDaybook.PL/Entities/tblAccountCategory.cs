namespace MJB.PocketDaybook.PL.Entities
{
    public class tblAccountCategory : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}
