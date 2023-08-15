using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(ControlWeighingConfiguration))]
public sealed class ControllWeighing: BaseTable
{
    public int? ControlWeighingSettingsId { get; set; } = null;
    [Ignore]
    public ControlWeighingSetting? ControlWeighingSettings { get; set; } = null;

    public int? WeightSettingId { get; set; } = null;
    [Ignore]
    public WeightSetting? WeightSetting { get; set; } = null;    

    public int? ControlWeighingStatusId { get; set; } = null;
    [Ignore]
    public ControlWeighingStatus? ControlWeighingStatus { get; set; } = null;
}
