using BillingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillingApp.Mappings
{
    internal class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Table & Schema
            builder.ToTable("Customers", "billing");

            // Primary Key
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("Id")
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.TenantId)
                   .HasColumnName("TenantId")
                   .IsRequired();

            builder.Property(x => x.Name)
                   .HasColumnName("Name")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Phone)
                   .HasColumnName("Phone")
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(x => x.Email)
                   .HasColumnName("Email")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Address)
                   .HasColumnName("Address")
                   .HasMaxLength(250);

            builder.Property(x => x.GSTNumber)
                   .HasColumnName("GSTNumber")
                   .HasMaxLength(20);

            builder.Property(x => x.CreatedAt)
                   .HasColumnName("CreatedAt")
                   .HasColumnType("datetime2")
                   .HasDefaultValueSql("SYSUTCDATETIME()");

            builder.Property(x => x.Active)
                   .HasColumnName("Active")
                   .HasColumnType("char(1)")
                   .HasDefaultValue('Y')
                   .IsRequired();

            // Index
            builder.HasIndex(x => x.TenantId)
                   .HasDatabaseName("IX_Customers_TenantId");
        }
    }
}
