using System.ComponentModel.DataAnnotations;

namespace CarRentalMoveZ.ViewModels
{
    public class PaymentViewModel
    {
        [Required]
        public int BookingId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero")]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; } // Card, Cash, Online

        [Required]
        public string Status { get; set; } // Paid, Pending, Failed
    }
}
