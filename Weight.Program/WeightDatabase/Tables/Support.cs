using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(SupportConfiguration))]
public sealed class Support: BaseTable, IInitializableCounter
{
    [Ignore]
    private static int _idCounter;
    public Support()
    {
        Id = _idCounter++;
    }
    public static void InitializeCounter(int initialValue)
    {
        _idCounter = initialValue;
    }

    public int? SupportServiceId { get; set; } = null;
    [Ignore]
    public SupportService? SupportService { get; set; } = null;

    public int? DepartmentId { get; set; } = null;
    [Ignore]
    public Department? Department { get; set; } = null;

    public int? WeightSettingId { get; set; } = null;
    [Ignore]
    public WeightSetting? WeightSetting { get; set; } = null;
}
