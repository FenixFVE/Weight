using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program.WeightDatabase.Configurations;

public sealed class SupportServiceConfiguration :
    IEntityTypeConfiguration<SupportService>
{
    public void Configure(EntityTypeBuilder<SupportService> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(c => c.Name);
        //.IsRequired()
        //.HasMaxLength(32);

        var options = new List<string>()
        {
            "ПККА",
            "Весовая группа",
            "Сеть",
            "ИТ",
            "Взвешивание"
        };
        builder.ToTable(t
             => t.HasCheckConstraint("CK_SupportService_Name",
             "Name IN (N'" + string.Join("', N'", options) + "')"));
    }
}