using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NwOrdersAPI.Entities;

namespace NwOrdersAPI
{
    // Users
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo");
            builder.HasKey(x => new { x.Id });

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired();
            builder.Property(x => x.Username).HasColumnName(@"Username").HasColumnType("varchar(255)").IsRequired().HasMaxLength(255).ValueGeneratedNever();
            builder.Property(x => x.PasswordHash).HasColumnName(@"PasswordHash").HasColumnType("binary(128)").IsRequired();
            builder.Property(x => x.PasswordSalt).HasColumnName(@"PasswordSalt").HasColumnType("binary(128)").IsRequired();
        }
    }

}

