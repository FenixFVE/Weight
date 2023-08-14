using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program.WeightDatabase.Configurations;

public class SupportConfiguration :
    IEntityTypeConfiguration<Support>
{
    public void Configure(EntityTypeBuilder<Support> builder)
    {
        builder.HasKey(k => k.Id);

        builder.HasOne(c => c.SupportService)
               .WithMany()
               .HasForeignKey(c => c.SupportServiceId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(c => c.Department)
               .WithMany()
               //.IsRequired()
               .HasForeignKey(c => c.DepartmentId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(c => c.WeightSetting)
               .WithMany()
               .HasForeignKey(c => c.WeightSettingId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}