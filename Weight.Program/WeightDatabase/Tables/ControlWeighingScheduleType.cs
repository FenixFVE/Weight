using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(ControlWeighingScheduleTypeConfiguration))]
public class ControlWeighingScheduleType
{

    public int ControlWeighningScheduleTypeId { get; set; }

    public string? Name { get; set; } = null;
}
