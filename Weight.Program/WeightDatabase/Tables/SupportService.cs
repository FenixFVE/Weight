using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;
using CsvHelper.Configuration.Attributes;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(SupportServiceConfiguration))]
public sealed class SupportService: BaseTable, IInitializableCounter
{
    [Ignore]
    private static int _idCounter;
    public SupportService()
    {
        Id = _idCounter++;
    }
    public static void InitializeCounter(int initialValue)
    {
        _idCounter = initialValue;
    }

    public string? Name { get; set; } = null;
}
