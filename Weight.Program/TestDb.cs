
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Weight.Program.WeightDatabase;
using Weight.Program.WeightDatabase.Tables;


public class TestContext: DbContext
{
    public DbSet<SupportService> SupportServices { get; set; }

    public TestContext()
    {
        if (!Database.CanConnect())
        {
            Database.EnsureCreated();
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=adb;Trusted_Connection=True")
            .AddInterceptors(new SoftDeleteInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = @".\Db\SupportService.csv";

        Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
        Console.WriteLine(File.Exists(resourceName) ? "Exist" : "Don't exist");

        base.OnModelCreating(modelBuilder);
    }

    public static void Print<T>(DbSet<T> set) where T : BaseTable
    {
        Console.WriteLine($"{typeof(T).Name} {{");
        foreach (var x in set)
        {
            Console.WriteLine($" Id: {x.Id}, IsDelete: {x.IsDelete}");
        }
        Console.WriteLine("}");
    }

    public static void TestAContextAsync()
    {
        using (var db = new TestContext())
        {
            db.Database.EnsureDeleted();
        }

        using (var db = new TestContext())
        {
            
        }
    }
}

