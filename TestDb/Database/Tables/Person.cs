using Microsoft.EntityFrameworkCore;
using TestDb.Database.Configurations;
using CsvHelper.Configuration.Attributes;

namespace TestDb.Database.Tables;

[EntityTypeConfiguration(typeof(PersonConfiguration))]
public sealed class Person: BaseTable
{
    [Ignore]
    private static uint _idCounter = 1;
    public Person()
    {
        Id = _idCounter++;
    }
    public static void InitializeCounter(uint initialValue)
    {
        _idCounter = initialValue;
    }

    public string? Name { get; set; } = null;
    public int? Age { get; set; } = null;
}
