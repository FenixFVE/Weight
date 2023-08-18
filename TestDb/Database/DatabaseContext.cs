using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using TestDb.Database.Tables;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestDb.Database;

public class DatabaseContext: DbContext
{
    public DbSet<Person> Persons { get; set; } = null!;

    public DatabaseContext(): base()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=testdb;Trusted_Connection=True")
            .AddInterceptors(new SoftDeleteInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().Property(b => b.Id).ValueGeneratedNever();

        base.OnModelCreating(modelBuilder);
    }

    public void SetInitialId()
    {
        Person.InitializeCounter(Persons.Any() ? Persons.Max(m => m.Id) + 1 : 1);
    }

    public void SeedFromCsv()
    {
        if (Database.CanConnect())
            Database.EnsureDeleted();
        Database.EnsureCreated();
        SetInitialId();

        var person1 = new Person() { Age = 20, Name = "Bob" };
        var person2 = new Person() { Age = 30, Name = "Stasy" };

        var persons = new List<Person>() { person1, person2 };

        Persons.AddRange(persons);

        SaveChanges();
    }
}
