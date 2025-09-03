using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalMoveZ.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        [Required]
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }   // Card, Cash, Online
        public string Status { get; set; }          // Paid, Pending, Failed
    }
}
