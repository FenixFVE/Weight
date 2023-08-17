using Microsoft.EntityFrameworkCore;
using TestDb.Database.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestDb.Database.Configurations;

public sealed class UserConfiguration :
    IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(k => k.Id);

        builder.HasOne(c => c.Person)
               .WithMany()
               .HasForeignKey(c => c.PersonId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
