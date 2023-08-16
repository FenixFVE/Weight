using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program.WeightDatabase;

public sealed class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context is null) return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry is not { State: EntityState.Deleted, Entity: BaseTable delete }) 
                continue;

            entry.State = EntityState.Modified;
            delete.IsDelete = true;
            delete.DeletedDate = DateTime.UtcNow;
        }
        return result;
    }
}