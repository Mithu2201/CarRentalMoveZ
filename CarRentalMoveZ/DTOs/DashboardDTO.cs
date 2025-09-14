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
        public List<string> EarningsMonths { get; set; }
        public List<decimal> EarningsRevenue { get; set; }

        public int BookedCount { get; set; }
        public int PendingCount { get; set; }
        public int CancelledCount { get; set; }
    }
}
