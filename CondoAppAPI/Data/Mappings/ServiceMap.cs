using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ServiceMap : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(e => e.Title)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(e => e.Description)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.Value)
                   .IsRequired();

            builder.Property(e => e.Phone)
                   .IsRequired();

            builder.Property(e => e.Address)
                   .IsRequired();
        }
    }
}
