namespace CarRentalMoveZ.ViewModels
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }

        public string Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Calculated
        public int Days { get; set; }
        public decimal Amount { get; set; }

        public string DriverStatus { get; set; }

        // Car Details
        public string CarName { get; set; }
        public string ImgURL { get; set; }
        public decimal PricePerDay { get; set; }

        // Customer Details
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
