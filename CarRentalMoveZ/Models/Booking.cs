using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalMoveZ.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        public int CarId { get; set; }
        [ForeignKey("CarId")]
        public Car Car { get; set; }

        [Required]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string Status { get; set; }   // Pending, Confirmed, Cancelled

        public String Location { get; set; }

        // Navigation
        public decimal Payment { get; set; }
    }
}
