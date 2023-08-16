using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(ControlWeighingConfiguration))]
public sealed class ControlWeighing: BaseTable
{
    public int? ControlWeighingSettingsId { get; set; } = null;
    [Ignore]
    public ControlWeighingSetting? ControlWeighingSettings { get; set; } = null;

    //public int? WeightSettingId { get; set; } = null;
    //[Ignore]
    //public WeightSetting? WeightSetting { get; set; } = null;    

    //public int? ControlWeighingStatusId { get; set; } = null;
    public int? WeighingStatusId { get; set; } = null;
    [Ignore]
    public ControlWeighingStatus? ControlWeighingStatus { get; set; } = null;

    public string? CargoName { get; set; } = null;
    public double? CargoWeight { get; set; } = null;
    public double? TolerableDeviationWeight { get; set; } = null;
    public double? ActualWeight { get; set; } = null;
    public bool IsManualMode { get; set; } = false;
    public int? WeightId { get; set; } = null;
    public string? Comment { get; set; } = null;
    public int? UserId { get; set; } = null;
    public DateTime? CreationDate { get; set; } = null;
    public bool IsManualModeSecondWeight { get; set; } = false;
    public int? SecondWeightId { get; set; } = null;
    public DateTime? DateOfWeighing { get; set; } = null;
    public double? ActualWeightSecond { get; set; } = null;
    public double? ActualWeightThree { get; set; } = null;
    public bool IsManualModeThreeWeight { get; set; } = false;
    public int? ThreeWeightId { get; set;} = null;
}
