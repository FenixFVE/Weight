using Microsoft.EntityFrameworkCore;
using TestDb.Database.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestDb.Database.Configurations;

public sealed class PersonConfiguration
    : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(k => k.Id);

        //builder.Property(p => p.Id)
    }
}
