namespace MJB.PocketDaybook.PL.Entities
{
    public class tblCurrencyExchange : IEntity
    {
        public Guid Id { get; set; }
        public Guid FromCurrencyId { get; set; }
        public Guid ToCurrencyId { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime Date { get; set; }
        public virtual tblCurrency FromCurrency { get; set; }
        public virtual tblCurrency ToCurrency { get; set; }

    }
}
