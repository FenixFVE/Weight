using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program.WeightDatabase.Configurations;

public sealed class WeightSettingConfiguration :
    IEntityTypeConfiguration<WeightSetting>
{
    public void Configure(EntityTypeBuilder<WeightSetting> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(c => c.Department)
               .WithMany()
               .HasForeignKey(c => c.DepartmentId)
               //.IsRequired()
               .OnDelete(DeleteBehavior.SetNull);
    }
}