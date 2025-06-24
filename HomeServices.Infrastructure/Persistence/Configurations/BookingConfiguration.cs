using HomeServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(b => b.BookingID);

        builder.Property(b => b.Price).HasColumnType("decimal(18,2)");
        builder.Property(b => b.Description).IsRequired();

        builder.HasOne(b => b.BookingStatus)
               .WithMany(bs => bs.Bookings)
               .HasForeignKey(b => b.BookingStatusId);
    }
}