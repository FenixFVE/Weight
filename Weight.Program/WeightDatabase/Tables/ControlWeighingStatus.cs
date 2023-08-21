using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;
using CsvHelper.Configuration.Attributes;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(ControlWeighingStatusConfiguration))]
public sealed class ControlWeighingStatus: BaseTable, IInitializableCounter
{
    [Ignore]
    private static int _idCounter;
    public ControlWeighingStatus()
    {
        Id = _idCounter++;
    }
    public static void InitializeCounter(int initialValue)
    {
        _idCounter = initialValue;
    }

    public string? Name { get; set; } = null;
    public int? Type { get; set; } = null;
}
