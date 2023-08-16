using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(ControlWeighingStatusConfiguration))]
public sealed class ControlWeighingStatus: BaseTable
{
    public string? Name { get; set; } = null;
    public int? Type { get; set; } = null;
}
