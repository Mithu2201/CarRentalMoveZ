using System.Collections.Generic;

namespace CarRentalMoveZ.DTOs
{
    public class CustomerDashboardDTO
    {

        // Profile information
        public IEnumerable<UserProfileDTO> Users{ get; set; }

        // Customer's bookings
        public IEnumerable<BookingDTO> Bookings { get; set; }

        // Customer's payments
        public IEnumerable<PaymentDTO> Payments { get; set; }
        public UserProfileDTO Profile { get; internal set; }
    }
}
