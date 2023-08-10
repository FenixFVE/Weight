using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program.WeightDatabase.Configurations;

public class ControlWeighingScheduleTypeConfiguration :
    IEntityTypeConfiguration<ControlWeighingScheduleType>
{
    public void Configure(EntityTypeBuilder<ControlWeighingScheduleType> builder)
    {
        builder.HasKey(k => k.ControlWeighningScheduleTypeId);

        builder.Property(c => c.Name)
            //.IsRequired()
            .HasMaxLength(32);

        builder.ToTable(t
            => t.HasCheckConstraint("CK_ControlWeighingScheduleType_Name",
            "Name IN ('Время от последнего взвешивания, мин', " +
            "'Кол-во взвешиваний', " +
            "'Вручную', " +
            "'Расписание по дням периода')"));
    }
}