using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program.WeightDatabase.Configurations;

public class ControlWeighingStatusConfiguration :
    IEntityTypeConfiguration<ControlWeighingStatus>
{
    public void Configure(EntityTypeBuilder<ControlWeighingStatus> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(c => c.Name)
            //.IsRequired()
            .HasMaxLength(32);

        builder.ToTable(t
             => t.HasCheckConstraint("CK_ControlWeighingStatus_Name",
             "Name IN ('Требуется контр. Взвешивание', " +
             "'Выполнено', " +
             "'Отколнено', " +
             "'Не пройдено')"));
    }
}
