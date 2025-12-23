using BillingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Table & Schema
        builder.ToTable("Users", "billing");

        // Primary Key
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnName("Id")
               .ValueGeneratedOnAdd();

        builder.Property(x => x.TenantId)
               .HasColumnName("TenantId")
               .IsRequired();

        builder.Property(x => x.RoleId)
               .HasColumnName("RoleId")
               .IsRequired();

        builder.Property(x => x.UserName)
               .HasColumnName("UserName")
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.PasswordHash)
               .HasColumnName("PasswordHash")
               .HasMaxLength(1000)
               .IsRequired();

        builder.Property(x => x.FirstName)
               .HasColumnName("FirstName")
               .HasMaxLength(100);

        builder.Property(x => x.LastName)
               .HasColumnName("LastName")
               .HasMaxLength(100);

        builder.Property(x => x.Email)
               .HasColumnName("Email")
               .HasMaxLength(200);

        builder.Property(x => x.CreatedAt)
               .HasColumnName("CreatedAt")
               .HasColumnType("datetime")
               .HasDefaultValueSql("GETDATE()");

        builder.Property(x => x.Active)
               .HasColumnName("Active")
               .HasColumnType("char(1)")
               .HasDefaultValue('Y')
               .IsRequired();

        // Indexes (recommended)
        builder.HasIndex(x => new { x.TenantId, x.UserName })
               .IsUnique()
               .HasDatabaseName("UX_Users_TenantId_UserName");

        builder.HasIndex(x => x.Active)
               .HasDatabaseName("IX_Users_Active");
    }
}
