using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program.WeightDatabase;

public class WeightContext: DbContext
{
    public DbSet<ControlWeighing> ControllWeighings { get; set; } = null!;
    public DbSet<ControlWeighingStatus> ControlWeighingStatuses { get; set; } = null!;
    public DbSet<ControlWeighingEvaluationType> ControlWeighingEvaluationTypes { get; set; } = null!;   
    public DbSet<ControlWeighingSetting> ControlWeighingSettings { get; set; } = null!;
    public DbSet<ControlWeighingScheduleType> controlWeighingScheduleTypes { get; set; } = null!;
    public DbSet<WeightSetting> WeightSettings { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Support> Supports { get; set; } = null!;
    public DbSet<SupportService> SupportServices { get; set; } = null!;

    public WeightContext()
    {
        //Database.EnsureDeleted();
        if (!Database.CanConnect())
        {
            Database.EnsureCreated();
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=weightdb;Trusted_Connection=True")
            .AddInterceptors(new SoftDeleteInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
