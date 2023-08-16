using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(ControlWeighingEvaluationTypeConfiguration))]
public sealed class ControlWeighingEvaluationType: BaseTable
{
    public string? Name { get; set; } = null;
    public int? Type { get; set; } = null;
}
