using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJB.PocketDaybook.PL.Entities
{
    public class tblItemPrices : IEntity
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public Guid MerchantId { get; set; }
        public Guid UserId { get; set; }
        public Guid TransactionId { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public virtual tblItem Item { get; set; }
        public virtual tblMerchant Merchant { get; set; }
        public virtual tblUser User { get; set; }
        public virtual tblTransaction Transaction { get; set; }
    }
}
