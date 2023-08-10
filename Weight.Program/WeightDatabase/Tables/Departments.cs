using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(DepartmentsConfiguration))]
public class Departments
{
    public int DeparmentId { get; set; }
}
