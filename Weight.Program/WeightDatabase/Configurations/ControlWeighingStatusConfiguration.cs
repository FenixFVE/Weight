using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program.WeightDatabase.Configurations;

public sealed class ControlWeighingStatusConfiguration :
    IEntityTypeConfiguration<ControlWeighingStatus>
{
    public void Configure(EntityTypeBuilder<ControlWeighingStatus> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(c => c.Name);
        //.IsRequired()
        //.HasMaxLength(32);

        var options = new List<string>
        {
            "Требуется контр. Взвешивание",
            "Выполнено",
            "Назначено",
            "В работе",
            "Отклонено",
            "Не пройдено"
        };
        builder.ToTable(t
             => t.HasCheckConstraint("CK_ControlWeighingStatus_Name",
             "Name IN (N'" + string.Join("', N'", options) + "')"));
    }
}
