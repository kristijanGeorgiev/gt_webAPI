using HomeServices.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class BookingEmployeeConfiguration : IEntityTypeConfiguration<BookingEmployee>
{
    public void Configure(EntityTypeBuilder<BookingEmployee> builder)
    {
        builder.HasKey(be => new { be.BookingId, be.EmployeeId });

        builder.HasOne(be => be.Booking)
               .WithMany(b => b.AssignedEmployees)
               .HasForeignKey(be => be.BookingId);

        builder.HasOne(be => be.Employee)
               .WithMany(e => e.AssignedBookings)
               .HasForeignKey(be => be.EmployeeId);
    }
}