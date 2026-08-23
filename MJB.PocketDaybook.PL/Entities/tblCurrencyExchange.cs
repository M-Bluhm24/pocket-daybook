namespace MJB.PocketDaybook.PL.Entities
{
    public class tblCurrencyExchange : IEntity
    {
        public Guid Id { get; set; }
        public string FromCurrencyCode { get; set; }
        public string ToCurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime Date { get; set; }
    
    }
}
