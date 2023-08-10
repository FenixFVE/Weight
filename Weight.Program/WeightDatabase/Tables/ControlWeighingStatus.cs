using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(ControlWeighingStatusConfiguration))]
public class ControlWeighingStatus
{
    public int ControlWeighingStatusId { get; set; }

    public string? Name { get; set; } = null;
}
