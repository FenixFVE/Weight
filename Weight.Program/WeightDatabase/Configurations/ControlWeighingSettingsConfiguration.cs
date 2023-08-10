using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program.WeightDatabase.Configurations;

public class ControlWeighingSettingsConfiguration
    : IEntityTypeConfiguration<ControlWeighingSettings>
{
    public void Configure(EntityTypeBuilder<ControlWeighingSettings> builder)
    {
        builder.HasKey(k => k.ControlWeighingSettigsId);

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
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(c => c.SecondWeightSetting)
               .WithMany()
               .HasForeignKey(c => c.SecondWeightSettingId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
