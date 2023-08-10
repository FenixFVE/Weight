using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(ControlWeighingEvaluationTypeConfiguration))]
public class ControlWeighingEvaluationType
{
    public int ControlWeighingEvaluationTypeId { get; set; }

    public string? Name { get; set; } = null;
}
