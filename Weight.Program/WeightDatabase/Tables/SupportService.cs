using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(SupportServiceConfiguration))]
public class SupportService
{
    public int SupportServiceId { get; set; }

    public string? Name { get; set; } = null;
}
