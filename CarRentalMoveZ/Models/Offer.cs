using System.ComponentModel.DataAnnotations;

namespace CarRentalMoveZ.Models
{
    public class Offer
    {
        [Key]
        public int OfferId { get; set; }

        [Required]
        [StringLength(50)]
        public string PromoCode { get; set; }  // e.g. "WELCOME10"

        [Required]
        [StringLength(100)]
        public string Title { get; set; }      // e.g. "10% Off on First Booking"

        [StringLength(255)]
        public string Description { get; set; } // Optional extra details

        [Range(1, 100)]
        public int DiscountPercentage { get; set; }  // e.g. 10 means 10%

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } // "Active" / "Expired" / "Upcoming"
    }
}
