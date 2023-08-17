
using Microsoft.EntityFrameworkCore;
using TestDb.Database;


//Console.WriteLine("Hello, World!");

using (var db = new DatabaseContext())
{
    Console.WriteLine("Connected");
    db.SeedFromCsv();
    var name = db.Persons.First().Name;
    Console.WriteLine(name);
}