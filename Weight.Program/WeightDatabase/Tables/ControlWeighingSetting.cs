using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(ControlWeighingSettingConfiguration))]
public sealed class ControlWeighingSetting: BaseTable
{
    public int? ControlWeighingScheduleTypeId { get; set; } = null;
    [Ignore]
    public ControlWeighingScheduleType? ControlWeighingScheduleType { get; set; } = null;

    public int? ControlWeighingEvaluationTypeId { get; set; } = null;
    [Ignore]
    public ControlWeighingEvaluationType? ControlWeighingEvaluationType { get; set; } = null;

    public int? WeightSettingId { get; set; } = null;
    [Ignore]
    public WeightSetting? WeightSetting { get; set; } = null;

    public int? SecondWeightSettingId { get; set; } = null;
    [Ignore]
    public WeightSetting? SecondWeightSetting { get; set; } = null;
}
