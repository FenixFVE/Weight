using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(WeightSettingConfiguration))]
public class WeightSetting
{
    public int WeightSettingId { get; set; }

    public int DepartmentId { get; set; }
    public Departments? Department { get; set; } = null;
}
