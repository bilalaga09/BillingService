using BillingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class RoleMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        // Table & Schema
        builder.ToTable("Roles", "billing");

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
               .HasMaxLength(50)
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

        // Relationships
        //builder.HasOne(x => x.Tenant)
        //       .WithMany()
        //       .HasForeignKey(x => x.TenantId)
        //       .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(x => new { x.TenantId, x.Name })
               .IsUnique()
               .HasDatabaseName("UX_Roles_TenantId_Name");

        builder.HasIndex(x => x.Active)
               .HasDatabaseName("IX_Roles_Active");
    }
}
