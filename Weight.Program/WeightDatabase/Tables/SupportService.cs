using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(SupportServiceConfiguration))]
public sealed class SupportService: BaseTable
{ 
    public string? Name { get; set; } = null;
}
