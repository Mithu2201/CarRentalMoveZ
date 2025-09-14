namespace CarRentalMoveZ.Repository.Interfaces
{
    public interface IDashboardRepository
    {
        Task<int> GetTotalBookingsAsync();
        Task<decimal> GetTotalRevenueAsync();
        Task<int> GetTotalCarsAsync();
        Task<int> GetAvailableCarsAsync();
        Task<int> GetTotalCustomersAsync();

        Task<List<(string Month, decimal Revenue)>> GetMonthlyRevenueAsync();

        Task<(int Booked, int Pending, int Cancelled)> GetBookingStatusCountsAsync();
    }
}
