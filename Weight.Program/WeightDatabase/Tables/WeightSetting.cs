using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(WeightSettingConfiguration))]
public sealed class WeightSetting: BaseTable
{
    public int? DepartmentId { get; set; } = null;
    [Ignore]
    public Department? Department { get; set; } = null;
    public string? IP { get; set; } = null;
    public int? Port { get; set; } = null;
    public string? Name { get; set; } = null;
    public bool IsEnable { get; set; } = false;
    public string? FromForm { get; set; } = null;
    public int? Type { get; set; } = null;
    public int? Platform { get; set; } = null;
    public int? InventoryNumber { get; set; } = null;
    public int? ModelName { get; set; } = null;
    public int? NumberOfWeighingsBeforeControlWeighing { get; set; } = null;
    public int? MinutesBeforeControlWeighing { get; set; } = null;
    public double? ControlCargoWeight { get; set; } = null;
    public double? TolerableDeviationWeight { get; set; } = null;
    public DateTime? AuditDate { get; set; } = null;
    public int? CreaterId { get; set; } = null;
    public int? ScalePollAlgorithmId { get; set; } = null;
    public string? ParseMask { get; set; } = null;
    public int? TimeOutRead { get; set; } = null;
    public int? NumberOfReadAttempts { get; set; } = null;
    public int? PauseBeetwenRead { get; set; } = null;
    public int? SourceFormId { get; set; } = null;
    public string? AnswerFormat { get; set; } = null;
    public string? WriteCommand { get; set; } = null;
    public int? UnitId { get; set; } = null;
    public int? WaitAfterSuccessWeight { get; set; } = null;
    public int? LoopCount { get; set; } = null;
}
