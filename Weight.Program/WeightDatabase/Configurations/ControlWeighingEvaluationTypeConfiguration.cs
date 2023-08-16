
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program.WeightDatabase.Configurations;

public sealed class ControlWeighingEvaluationTypeConfiguration :
            IEntityTypeConfiguration<ControlWeighingEvaluationType>
{
    public void Configure(EntityTypeBuilder<ControlWeighingEvaluationType> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            //.IsRequired()
            .HasMaxLength(32);

        builder.ToTable(t
            => t.HasCheckConstraint("CK_ControlWeighingEvaluationType_Name",
            "Name IN ('от контрольного груза', 'отклонение 2-x взвешиваний')"));
    }
}
