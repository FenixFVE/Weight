using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(WeightSettingConfiguration))]
public sealed class WeightSetting: BaseTable
{
    public int? DepartmentId { get; set; } = null;
    public Department? Department { get; set; } = null;
}
