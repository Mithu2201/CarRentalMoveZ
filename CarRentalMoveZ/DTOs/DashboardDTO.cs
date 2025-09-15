namespace CarRentalMoveZ.DTOs
{
    public class DashboardDTO
    {
        public int TotalBookings { get; set; }
        public decimal TotalRevenue { get; set; }
        public int AvailableCars { get; set; }
        public int TotalCars { get; set; }
        public int TotalCustomers { get; set; }

        // Chart data
        public List<string> EarningsHours { get; set; }
        public List<decimal> EarningsRevenue { get; set; }

        // Booking overview chart
        // For hourly booking chart
        public List<string> BookingHours { get; set; }    // labels: "09:00", "10:00", etc.
        public List<int> BookingCounts { get; set; }      // number of bookings per hour

        // Car status chart
        public int AvailableCarCount { get; set; }
        public int BookedCarCount { get; set; }
        public int PendingCarCount { get; set; }


        public int BookedCount { get; set; }
        public int PendingCount { get; set; }
        public int CancelledCount { get; set; }
    }
}
