﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program.WeightDatabase.Configurations;

public class WeightSettingConfiguration :
    IEntityTypeConfiguration<WeightSetting>
{
    public void Configure(EntityTypeBuilder<WeightSetting> builder)
    {
        builder.HasKey(x => x.WeightSettingId);

        builder.HasOne(c => c.Department)
               .WithMany()
               .HasForeignKey(c => c.DepartmentId)
               //.IsRequired()
               .OnDelete(DeleteBehavior.SetNull);
    }
}