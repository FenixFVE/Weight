using Microsoft.EntityFrameworkCore;
using TestDb.Database.Configurations;

namespace TestDb.Database.Tables;

[EntityTypeConfiguration(typeof(PersonConfiguration))]
public sealed class Person: BaseTable
{
    public string? Name { get; set; } = null;
    public int? Age { get; set; } = null;
}
