using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program.WeightDatabase.Configurations;

public class SupportServiceConfiguration :
    IEntityTypeConfiguration<SupportService>
{
    public void Configure(EntityTypeBuilder<SupportService> builder)
    {
        builder.HasKey(k => k.SupportServiceId);

        builder.Property(c => c.Name)
            //.IsRequired()
            .HasMaxLength(32);

        builder.ToTable(t
             => t.HasCheckConstraint("CK_SupportService_Name",
             "Name IN ('ПККА', " +
             "'Весовая группа', " +
             "'Сеть', " +
             "'ИТ', " +
             "'Взвешивание')"));
    }
}