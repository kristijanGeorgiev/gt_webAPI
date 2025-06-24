using HomeServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(i => i.InvoiceID);
        builder.Property(i => i.Amount).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(i => i.Tax).IsRequired();
        builder.Property(i => i.Quantity).IsRequired();
        builder.Property(i => i.IssuedDate).IsRequired();
        builder.Property(i => i.DueDate).IsRequired();
        builder.Property(i => i.IsPaid).IsRequired();
        builder.HasOne(i => i.Booking)
       .WithMany()
       .HasForeignKey(i => i.BookingID)
       .OnDelete(DeleteBehavior.Restrict);
    }
}