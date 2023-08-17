using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using TestDb.Database.Configurations;

namespace TestDb.Database.Tables;

[EntityTypeConfiguration(typeof(UserConfiguration))]
public sealed class User: BaseTable
{
    public int? PersonId { get; set; } = null;
    [Ignore]
    public Person? Person { get; set; } = null;

    public string? Password { get; set; } = null;
}
