using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BillingApp.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? GSTNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
