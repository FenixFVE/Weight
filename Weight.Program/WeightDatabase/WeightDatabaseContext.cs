using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Tables;
using Weight.Program.CSV;

namespace Weight.Program.WeightDatabase;

public class WeightContext: DbContext
{

    public DbSet<ControlWeighing> ControlWeighings { get; set; } = null!;
    public DbSet<ControlWeighingStatus> ControlWeighingStatuses { get; set; } = null!;
    public DbSet<ControlWeighingEvaluationType> ControlWeighingEvaluationTypes { get; set; } = null!;   
    public DbSet<ControlWeighingSetting> ControlWeighingSettings { get; set; } = null!;
    public DbSet<ControlWeighingScheduleType> ControlWeighingScheduleTypes { get; set; } = null!;
    public DbSet<WeightSetting> WeightSettings { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Support> Supports { get; set; } = null!;
    public DbSet<SupportService> SupportServices { get; set; } = null!;

    public WeightContext() 
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=weightdb;Trusted_Connection=True")
            .AddInterceptors(new SoftDeleteInterceptor());
        base.OnConfiguring(optionsBuilder);
    }


    public void SetInitialId<T>(DbSet<T> set) where T : BaseTable, IInitializableCounter
    {
        T.InitializeCounter(set.Any() ? set.Max(m => m.Id) + 1 : 1);
    }

    public void SetInitialId()
    {
        SetInitialId(ControlWeighings);
        SetInitialId(ControlWeighingStatuses);
        SetInitialId(ControlWeighingEvaluationTypes);
        SetInitialId(ControlWeighingSettings);
        SetInitialId(ControlWeighingScheduleTypes);
        SetInitialId(WeightSettings);
        SetInitialId(Departments);
        SetInitialId(Supports);
        SetInitialId(SupportServices);
    }

    private void SeedFromCsv<T>(DbSet<T> set) where T : BaseTable
    {
        set.AddRange(CsvTableReader.Read<T>());
    }

    public void SeedFromCsv()
    {
        if (Database.CanConnect())
            Database.EnsureDeleted();
        Database.EnsureCreated();

        SeedFromCsv(ControlWeighings);
        SeedFromCsv(ControlWeighingStatuses);
        SeedFromCsv(ControlWeighingEvaluationTypes);
        SeedFromCsv(ControlWeighingSettings);
        SeedFromCsv(ControlWeighingScheduleTypes);
        SeedFromCsv(WeightSettings);
        SeedFromCsv(Departments);
        //SeedFromCsv(Supports);
        SeedFromCsv(SupportServices);

        SaveChanges();

        SetInitialId();
    }

}
