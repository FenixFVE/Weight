using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using TestDb.Database.Tables;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestDb.Database;

public class DatabaseContext: DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Person> Persons { get; set; } = null!;

    public DatabaseContext(): base()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=testdb;Trusted_Connection=True")
            .AddInterceptors(new SoftDeleteInterceptor());
    }

    public void SeedFromCsv()
    {
        if (Database.CanConnect())
            Database.EnsureDeleted();
        Database.EnsureCreated();

        var person1 = new Person() { Id = 2, Age = 20, Name = "Bob" };
        var person2 = new Person() { Id = 3, Age = 30, Name = "Stasy" };

        //var user1 = new User() { Id = 5, Person = person1, Password = "1234" };
        //var user2 = new User() { Id = 6, Person = person1, Password = "pasword" };
        //var user3 = new User() { Id = 7, Person = person2, Password = "qwerty" };

        var persons = new List<Person>() { person1, person2 };
        //var users = new List<User>() { user1, user2, user3 };


        Persons.AddRange(persons);
        //Users.AddRange(users);
        

        SaveChanges();
    }

}
