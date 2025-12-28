using BillingApp.Models;
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
               .HasColumnName("Id")
               .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
               .HasColumnName("Name")
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(x => x.Code)
       .HasColumnName("Code")
       .HasMaxLength(50);

        builder.Property(x => x.Phone)
               .HasColumnName("Phone")
               .HasMaxLength(20);

        builder.Property(x => x.Email)
               .HasColumnName("Email")
               .HasMaxLength(200);

        builder.Property(x => x.Address)
               .HasColumnName("Address")
               .HasMaxLength(300);

        builder.Property(x => x.SubscriptionPlan)
               .HasColumnName("SubscriptionPlan")
               .HasMaxLength(100);

        builder.Property(x => x.SubscriptionStartDate)
               .HasColumnName("SubscriptionStartDate")
               .HasColumnType("datetime")
               .IsRequired();

        builder.Property(x => x.SubscriptionExpiryDate)
               .HasColumnName("SubscriptionExpiryDate")
               .HasColumnType("datetime")
               .IsRequired();

        builder.Property(x => x.CreatedAt)
               .HasColumnName("CreatedAt")
               .HasColumnType("datetime")
               .HasDefaultValueSql("GETDATE()");

        builder.Property(x => x.Active)
               .HasColumnName("Active")
               .HasColumnType("char(1)")
               .HasDefaultValue('Y')
               .IsRequired();

        // Optional index for Active
        builder.HasIndex(x => x.Active)
               .HasDatabaseName("IX_Tenants_Active");
    }
}
