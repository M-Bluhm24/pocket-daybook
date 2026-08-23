namespace MJB.PocketDaybook.PL.Entities
{
    public class tblCurrency : IEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int DecimalPlaces { get; set; }
    }
}
