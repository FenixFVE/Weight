
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

    public static void TestAContext()
    {
        using (var db = new AContext())
        {
            db.Database.EnsureDeleted();
        }

        using (var db = new AContext())
        {
            var a = new A { Name = "One" };
            var b = new A { Name = "Two" };
            db.AddRange(a, b);
            db.SaveChanges();
        }

        using (var db = new AContext())
        {
            Console.WriteLine("{");
            foreach (var a in db.As)
            {
                Console.WriteLine(" " + a);
            }
            Console.WriteLine("}");
        }

        using (var db = new AContext())
        {
            var a = db.As.FirstOrDefault();
            if (a is not null)
            {
                db.As.Remove(a);
                db.SaveChanges();
            }
        }

        using (var db = new AContext())
        {
            Console.WriteLine("{");
            foreach (var a in db.As)
            {
                Console.WriteLine(" " + a);
            }
            Console.WriteLine("}");
        }
    }
}

