
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

        //builder.Property(c => c.Name);
        //    .IsRequired()
        //    .HasMaxLength(32);

        var options = new List<string>()
        {
            "от контрольного груза",
            "отклонение 2-х взвешиваний",
            "отклонение 3-х взвешиваний"
        };
        builder.ToTable(t
            => t.HasCheckConstraint("CK_ControlWeighingEvaluationType_Name",
            "Name IN (N'" + string.Join("', N'", options) + "')"));
    }
}
