using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class TenantMap : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        // Table & Schema
        builder.ToTable("Tenants", "billing");

        // Primary Key
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               //.HasColumnName("TenantId")
               .HasColumnName("Id")
               .ValueGeneratedOnAdd();

        // Tenant Code
        builder.Property(x => x.TenantCode)
               .HasColumnName("TenantCode")
               .IsRequired()
               .HasMaxLength(50);

        // Tenant Name
        builder.Property(x => x.TenantName)
               .HasColumnName("TenantName")
               .IsRequired()
               .HasMaxLength(150);

        // Email
        builder.Property(x => x.Email)
               .HasColumnName("Email")
               .HasMaxLength(100);

        // Phone
        builder.Property(x => x.Phone)
               .HasColumnName("Phone")
               .HasMaxLength(20);

        // Active flag
        builder.Property(x => x.Active) // fixed property name to match model
               .HasColumnName("Active")
               .HasColumnType("char(1)")
               .HasDefaultValue('Y')
               .IsRequired();

        // CreatedAt
        builder.Property(x => x.CreatedAt)
               .HasColumnName("CreatedAt")
               .HasColumnType("datetime2")
               .HasDefaultValueSql("SYSUTCDATETIME()");

        // Indexes
        builder.HasIndex(x => x.TenantCode)
               .IsUnique()
               .HasDatabaseName("UX_Tenants_TenantCode");

        builder.HasIndex(x => x.Active)
               .HasDatabaseName("IX_Tenants_Active");
    }
}
