
using Microsoft.EntityFrameworkCore;
using TestDb.Database;


//Console.WriteLine("Hello, World!");

using (var db = new DatabaseContext())
{
    Console.WriteLine("Connected");
    db.SeedFromCsv();
    
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