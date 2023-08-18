using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program.WeightDatabase.Configurations;

public sealed class ControlWeighingScheduleTypeConfiguration :
    IEntityTypeConfiguration<ControlWeighingScheduleType>
{
    public void Configure(EntityTypeBuilder<ControlWeighingScheduleType> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(c => c.Name);
        //.IsRequired()
        //.HasMaxLength(32);

        var options = new List<string>()
        {
            "Время от последнего взвешивания, мин",
            "Кол-во взвешиваний",
            "Вручную",
            "Расписание по дням периода"
        };
        builder.ToTable(t
            => t.HasCheckConstraint("CK_ControlWeighingScheduleType_Name",
            "Name IN (N'" + string.Join("', N'", options) + "')"));
    }
}