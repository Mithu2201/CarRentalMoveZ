using System.ComponentModel.DataAnnotations;

namespace CarRentalMoveZ.ViewModels
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Select Pickup location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Select a valid date")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Select a valid date")]
        public DateTime? EndDate { get; set; }

        // Calculated
        public int Days { get; set; }
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Select Driver status")]
        public string DriverStatus { get; set; }

        // Car Details
        public string CarName { get; set; }
        public string ImgURL { get; set; }
        public decimal PricePerDay { get; set; }

        // Customer Details

        [Required(ErrorMessage = "Name is reqired")]
        public string CustomerName { get; set; }

        
        public string PhoneNumber { get; set; }
    }
}
