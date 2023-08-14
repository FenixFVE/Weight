using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(ControlWeighingScheduleTypeConfiguration))]
public sealed class ControlWeighingScheduleType: BaseTable
{
    public string? Name { get; set; } = null;
}
