using Microsoft.EntityFrameworkCore;
using System.Data;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(SupportServiceConfiguration))]
public sealed class SupportService: BaseTable
{ 
    public string? Name { get; set; } = null;
    public DateTime? AuditDate { get; set; } = null;
    public int? CreaterId { get; set; } = null;
}
