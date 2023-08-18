
using Microsoft.EntityFrameworkCore;
using TestDb.Database.Tables;
using TestDb.Database;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;


Console.WriteLine("Hello, World!");

using (var db = new DatabaseContext())
{
    Console.WriteLine("Connected");
    db.SeedFromCsv();
    db.SetInitialId();

    foreach (var person in db.Persons)
    {
        Console.WriteLine($"{person.Id} : {person.Name}");
    }
    Console.WriteLine("---");
    
    db.SaveChanges();

    foreach (var person in db.Persons)
    {
        Console.WriteLine($"{person.Id} : {person.Name}");
    }
}

