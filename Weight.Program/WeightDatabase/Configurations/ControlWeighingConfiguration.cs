using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program.WeightDatabase.Configurations;

public sealed class ControlWeighingConfiguration :
            IEntityTypeConfiguration<ControlWeighing>
{
    public void Configure(EntityTypeBuilder<ControlWeighing> builder)
    {
        builder.HasKey(c => c.Id);


        builder.HasOne(c => c.ControlWeighingSettings)
               .WithMany()
               .HasForeignKey(c => c.ControlWeighingSettingsId)
               .OnDelete(DeleteBehavior.SetNull);

        //builder.HasOne(c => c.WeightSetting)
        //       .WithMany()
        //       .HasForeignKey(c => c.WeightSettingId)
        //       .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(c => c.ControlWeighingStatus)
               .WithMany()
               //.HasForeignKey(c => c.ControlWeighingStatusId)
               .HasForeignKey(c => c.WeighingStatusId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
