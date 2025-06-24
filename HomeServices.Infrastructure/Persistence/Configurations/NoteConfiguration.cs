using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HomeServices.Domain.Entities;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.HasKey(n => n.NotesId);

        builder.Property(n => n.NoteText)
               .IsRequired()
               .HasMaxLength(1000);

        builder.Property(n => n.CheckIn)
    .HasConversion(
        v => v.ToTimeSpan(),
        v => TimeOnly.FromTimeSpan(v))
    .HasColumnType("time")
    .IsRequired();

        builder.Property(n => n.CheckOut)
            .HasConversion(
                v => v.ToTimeSpan(),
                v => TimeOnly.FromTimeSpan(v))
            .HasColumnType("time")
            .IsRequired();

        builder.HasOne(n => n.Booking)
               .WithMany()
               .HasForeignKey(n => n.BookingId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(n => n.Employee)
               .WithMany()
               .HasForeignKey(n => n.UserId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
