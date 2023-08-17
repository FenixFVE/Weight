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
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=weightdb;Trusted_Connection=True")
            .AddInterceptors(new SoftDeleteInterceptor());
        //base.OnConfiguring(optionsBuilder);
    }

    public void SeedFromCsv()
    {
        if (Database.CanConnect())
            Database.EnsureDeletedAsync();
        Database.EnsureCreated();

        Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ControlWeighings ON");
        Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ControlWeighingStatuses ON");
        Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ControlWeighingEvaluationTypes ON");
        Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ControlWeighingSettings ON");
        Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ControlWeighingScheduleTypes ON");
        Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.WeightSettings ON");
        Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Departments ON");
        Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.SupportServices ON");

        ControlWeighings.AddRange(CsvTableReader.Read<ControlWeighing>());
        ControlWeighingStatuses.AddRange(CsvTableReader.Read<ControlWeighingStatus>());
        ControlWeighingEvaluationTypes.AddRange(CsvTableReader.Read<ControlWeighingEvaluationType>());
        ControlWeighingSettings.AddRange(CsvTableReader.Read<ControlWeighingSetting>());
        ControlWeighingScheduleTypes.AddRange(CsvTableReader.Read<ControlWeighingScheduleType>());
        WeightSettings.AddRange(CsvTableReader.Read<WeightSetting>());
        Departments.AddRange(CsvTableReader.Read<Department>());
        //Supports.AddRange(CsvTableReader.Read<Support>());
        SupportServices.AddRange(CsvTableReader.Read<SupportService>());

        Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ControlWeighings OFF");
        Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ControlWeighingStatuses OFF");
        Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ControlWeighingEvaluationTypes OFF");
        Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ControlWeighingSettings OFF");
        Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ControlWeighingScheduleTypes OFF");
        Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.WeightSettings OFF");
        Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Departments OFF");
        Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.SupportServices OFF");

        SaveChanges();
    }

}
