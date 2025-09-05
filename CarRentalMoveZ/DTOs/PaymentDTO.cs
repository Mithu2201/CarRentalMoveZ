namespace CarRentalMoveZ.DTOs
{
    public class PaymentDTO
    {
        public int PaymentId { get; set; }

        public int BookingId { get; set; }

        // Optional: include some booking details if useful
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string PaymentMethod { get; set; }

        public string Status { get; set; }
    }
}
