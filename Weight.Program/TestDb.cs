
using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase;
using Weight.Program.WeightDatabase.Tables;

public sealed class A: BaseTable
{
    public string? Name { get; set; } = null;

    public override string ToString()
        => $"Id:{Id},IsDelet:{IsDelete},Name:{Name}";
}

public class AContext: DbContext
{
    public DbSet<A> As { get; set; }

    public AContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=adb;Trusted_Connection=True")
            .AddInterceptors(new SoftDeleteInterceptor());
    }
}
