namespace CarRentalMoveZ.Repository.Interfaces
{
    public interface IDashboardRepository
    {
        Task<int> GetTotalBookingsAsync();
        Task<decimal> GetTotalRevenueAsync();
        Task<int> GetTotalCarsAsync();
        Task<int> GetAvailableCarsAsync();
        Task<int> GetTotalCustomersAsync();

        Task<List<(string Hour, decimal Revenue)>> GetHourlyRevenueAsync(DateTime date);

        Task<List<(string Hour, int Count)>> GetHourlyBookingCountsAsync(DateTime date);

        Task<(int Available, int Booked, int Pending)> GetCarStatusCountsAsync();

        Task<(int Booked, int Pending, int Cancelled)> GetBookingStatusCountsAsync();
    }
}
