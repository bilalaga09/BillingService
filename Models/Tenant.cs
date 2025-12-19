using BillingApp.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Tenant
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string TenantCode { get; set; } = null!;

    [Required]
    [MaxLength(150)]
    public string TenantName { get; set; } = null!;

    [MaxLength(100)]
    public string? Email { get; set; }

    [MaxLength(20)]
    public string? Phone { get; set; }

    // Y = Active, N = Inactive (Soft state)
    public char Active { get; set; } = 'Y';

    public DateTime CreatedAt { get; set; }

    
}
