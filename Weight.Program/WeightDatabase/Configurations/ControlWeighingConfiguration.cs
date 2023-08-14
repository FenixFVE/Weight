using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program.WeightDatabase.Configurations;

public class ControlWeighingConfiguration :
            IEntityTypeConfiguration<ControllWeighing>
{
    public void Configure(EntityTypeBuilder<ControllWeighing> builder)
    {
        builder.HasKey(c => c.ControllWeighingId);


        builder.HasOne(c => c.ControlWeighingSettings)
               .WithMany()
               .HasForeignKey(c => c.ControlWeighingSettingsId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(c => c.WeightSetting)
               .WithMany()
               .HasForeignKey(c => c.WeightSettingId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(c => c.ControlWeighingStatus)
               .WithMany()
               .HasForeignKey(c => c.ControlWeighingStatusId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
