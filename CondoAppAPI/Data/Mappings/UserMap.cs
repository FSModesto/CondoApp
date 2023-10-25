using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Name)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(e => e.Email)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.BirthDate)
                   .IsRequired();

            builder.Property(e => e.Document)
                   .IsRequired();

            builder.Property(e => e.Password)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(e => e.Type)
                   .IsRequired();

            builder.HasMany(e => e.Services)
                   .WithOne(e => e.User)
                   .HasForeignKey(fk => fk.UserId);

            builder.HasMany(e => e.Messages)
                   .WithOne(e => e.User)
                   .HasForeignKey(fk => fk.UserId);
        }
    }
}
