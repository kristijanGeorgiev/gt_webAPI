
using HomeServices.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(s => s.ServiceID);
        builder.Property(s => s.Name).IsRequired();
        builder.Property(s => s.Description).IsRequired();
        builder.Property(s => s.Price).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(s => s.IsAvailable).IsRequired();
        builder.Property(s => s.Image).IsRequired();
    }
}