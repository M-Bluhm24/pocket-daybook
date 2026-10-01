using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJB.PocketDaybook.PL.Entities
{
    public class tblItem : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual tblUser User { get; set; }
        public virtual ICollection<tblItemPrices> ItemPrices { get; set; } = new List<tblItemPrices>();
    }
}
