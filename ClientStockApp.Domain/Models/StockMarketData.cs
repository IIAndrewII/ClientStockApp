using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientStockApp.Domain.Models
{
    public class StockMarketData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[A-Z]+$", ErrorMessage = "Symbol must be uppercase letters.")]
        public string Symbol { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        [CustomValidation(typeof(StockMarketData), nameof(ValidateTimestamp))]
        public DateTime Timestamp { get; set; }

        public static ValidationResult ValidateTimestamp(DateTime timestamp, ValidationContext context)
        {
            if (timestamp > DateTime.Now)
            {
                return new ValidationResult("Timestamp cannot be in the future.");
            }
            return ValidationResult.Success;
        }
    }
}
