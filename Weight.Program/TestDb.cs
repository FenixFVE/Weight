
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Reflection;
using System.Text;
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
        base.OnModelCreating(modelBuilder);

        var assembly = Assembly.GetExecutingAssembly();
        var cvsDirectory = $@"{AppDomain.CurrentDomain.BaseDirectory}\..\..\..\CSVs";
        var resourceName = $@"{cvsDirectory}\SupportService.csv";
        //Console.WriteLine(File.Exists(resourceName));
        using (var stream = assembly.GetManifestResourceStream(resourceName))
        using (var reader = new StreamReader(stream, Encoding.UTF8))
        {
            var csfConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
            var csvReader = new CsvReader(reader, csfConfig);
            var supportServices = csvReader.GetRecords<SupportService>().ToArray();
            SupportServices.AddRange(supportServices);
            this.SaveChanges();
        }
        
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

