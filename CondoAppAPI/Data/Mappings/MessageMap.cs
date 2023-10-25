using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class MessageMap : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(e => e.Title)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(e => e.Description)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.HasBeenReaded)
                   .IsRequired();

            builder.Property(e => e.DateTime)
                   .IsRequired();

            builder.Property(e => e.Type)
                   .IsRequired();
        }
    }
}
