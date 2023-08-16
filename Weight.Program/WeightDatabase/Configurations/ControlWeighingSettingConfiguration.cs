using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program.WeightDatabase.Configurations;

public sealed class ControlWeighingSettingConfiguration
    : IEntityTypeConfiguration<ControlWeighingSetting>
{
    public void Configure(EntityTypeBuilder<ControlWeighingSetting> builder)
    {
        builder.HasKey(k => k.Id);

        builder.HasOne(c => c.ControlWeighingScheduleType)
               .WithMany()
               .HasForeignKey(c => c.ControlWeighingScheduleTypeId)
               //.IsRequired()
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(c => c.ControlWeighingEvaluationType)
               .WithMany()
               .HasForeignKey(c => c.ControlWeighingEvaluationTypeId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(c => c.WeightSetting)
               .WithMany()
               .HasForeignKey(c => c.WeightSettingId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.SecondWeightSetting)
               .WithMany()
               .HasForeignKey(c => c.SecondWeightSettingId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
