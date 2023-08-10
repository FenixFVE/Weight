using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(SupportConfiguration))]
public class Support
{
    public int SupportId { get; set; }

    public int? SupportServiceId { get; set; } = null;
    public SupportService? SupportService { get; set; } = null;

    public int? DepartmentId { get; set; } = null;
    public Departments? Department { get; set; } = null;

    public int? WeightSettingId { get; set; } = null;
    public WeightSetting? WeightSetting { get; set; } = null;
}
