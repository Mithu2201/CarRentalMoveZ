using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;

namespace CarRentalMoveZ.ViewModels
{
    public class BookingDetailsViewModel
    {
        public int BookingId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string Location { get; set; }

        public string BookingStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        // Calculated
        public int Days { get; set; }
        public decimal Amount { get; set; }
        // Car Details
        public string CarName { get; set; } = "";       // default empty string
        public string? ImgURL { get; set; }             // nullable, can remain null
        public decimal PricePerDay { get; set; } = 0m;  // default 0

        public string DriverStatus { get; set; }

        public int? DriverId { get; set; }                  // Selected driver
        public IEnumerable<DriverDTO>? AvailableDrivers { get; set; } // List of available drivers

        // Customer Details
        public string CustomerName { get; set; } = "";  // default empty string
        public string? PhoneNumber { get; set; }        // nullable

        // Payment Details
        public bool IsPaid { get; set; } = false;       // default false
        public decimal PaymentAmount { get; set; } = 0m;// default 0
        public DateTime? PaymentDate { get; set; }      // nullable
        public string? PaymentMethod { get; set; }      // nullable
        public string? PaymentStatus { get; set; }      // nullable

        public DateTime? StatusUpdatedAt { get; set; } // <-- new property

    }
}

