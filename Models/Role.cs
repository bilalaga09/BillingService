using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingApp.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int TenantId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        // Y = Active, N = Inactive
        public char Active { get; set; } = 'Y';

        // Navigation
        //public Tenant Tenant { get; set; } = null!;
    }
}
