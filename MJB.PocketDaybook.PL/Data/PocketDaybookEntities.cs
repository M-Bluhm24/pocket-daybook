using MJB.PocketDaybook.PL.Entities;
using Microsoft.EntityFrameworkCore;

namespace MJB.PocketDaybook.PL.Data
{
    public class PocketDaybookEntities : DbContext
    {
        Guid[] accountId = new Guid[4];
        Guid[] budgetId = new Guid[4];
        Guid[] budgetItemsId = new Guid[8];
        Guid[] goalId = new Guid[6];

    }
}
