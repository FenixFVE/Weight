using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(ControlWeighingSettingsConfiguration))]
public class ControlWeighingSettings
{
    public int ControlWeighingSettigsId { get; set; }

    public int? ControlWeighingScheduleTypeId { get; set; } = null;
    public ControlWeighingScheduleType? ControlWeighingScheduleType { get; set; } = null;

    public int? ControlWeighingEvaluationTypeId { get; set; } = null;
    public ControlWeighingEvaluationType? ControlWeighingEvaluationType { get; set; } = null;

    public int? WeightSettingId { get; set; } = null;
    public WeightSetting? WeightSetting { get; set; } = null;

    public int? SecondWeightSettingId { get; set; } = null;
    public WeightSetting? SecondWeightSetting { get; set; } = null;
}
