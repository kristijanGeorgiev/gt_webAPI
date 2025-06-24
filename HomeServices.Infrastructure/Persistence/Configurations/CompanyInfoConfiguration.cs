using HomeServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CompanyInfoConfiguration : IEntityTypeConfiguration<CompanyInfo>
{
    public void Configure(EntityTypeBuilder<CompanyInfo> builder)
    {
        builder.HasKey(c => c.companyId);

        builder.Property(c => c.companyName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.companyAddress)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(c => c.TaxNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.Bank)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.BankAccount)
            .IsRequired()
            .HasMaxLength(100);
    }
}
