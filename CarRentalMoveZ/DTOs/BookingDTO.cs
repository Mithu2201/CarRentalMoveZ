namespace CarRentalMoveZ.DTOs
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
       
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public decimal Payment { get; set; }

        // Flatten related entities
        public string CustomerName { get; set; }
        public string CarModel { get; set; }
        public string DriverStatus { get; set; }

        public string Image { get; set; }

    }
}
