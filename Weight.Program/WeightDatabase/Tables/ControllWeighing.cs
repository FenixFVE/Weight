using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(ControlWeighingConfiguration))]
public class ControllWeighing
{
    public int ControllWeighingId { get; set; }

    public int? ControlWeighingSettingsId { get; set; } = null;
    public ControlWeighingSettings? ControlWeighingSettings { get; set; } = null;

    public int? WeightSettingId { get; set; } = null;
    public WeightSetting? WeightSetting { get; set; } = null;    

    public int? ControlWeighingStatusId { get; set; } = null;
    public ControlWeighingStatus? ControlWeighingStatus { get; set; } = null;
}
