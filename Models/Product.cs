using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingApp.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int TenantId { get; set; }

        [MaxLength(200)]
        public string? Name { get; set; }

        public int? CategoryId { get; set; }
        public int? UnitId { get; set; }

        [MaxLength(100)]
        public string? SKU { get; set; }

        [MaxLength(100)]
        public string? Barcode { get; set; }

        [MaxLength(20)]
        public string? HSNCode { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? PurchasePrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? SalesPrice { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? TaxRate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? OpeningStock { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? CurrentStock { get; set; }

        // Use a char flag for Active state. Default to 'Y' for newly created products.
        public char Active { get; set; } = 'Y';
    }
}
