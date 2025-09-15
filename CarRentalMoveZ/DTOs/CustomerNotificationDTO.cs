namespace CarRentalMoveZ.DTOs
{
    public class CustomerNotificationDTO
    {
        public int BookingId { get; set; }
        public string CarName { get; set; }
        public string DriverName { get; set; }
        public DateTime? AssignedAt { get; set; } // StatusUpdatedAt
    }
}
