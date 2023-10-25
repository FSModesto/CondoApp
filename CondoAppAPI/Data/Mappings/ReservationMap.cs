using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ReservationMap : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(e => e.Title)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(e => e.LeisureSpace)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.DateTime)
                   .IsRequired();
        }
    }
}
