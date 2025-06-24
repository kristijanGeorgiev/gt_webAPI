using HomeServices.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class WorkPositionConfiguration : IEntityTypeConfiguration<WorkPosition>
{
    public void Configure(EntityTypeBuilder<WorkPosition> builder)
    {
        builder.HasKey(wp => wp.Id);
        builder.Property(wp => wp.Name).IsRequired();
    }
}