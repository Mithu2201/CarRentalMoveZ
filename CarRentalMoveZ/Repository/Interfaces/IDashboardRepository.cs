namespace CarRentalMoveZ.Repository.Interfaces
{
    public interface IDashboardRepository
    {
        Task<int> GetTotalBookingsAsync();
        Task<decimal> GetTotalRevenueAsync();
        Task<int> GetTotalCarsAsync();
        Task<int> GetAvailableCarsAsync();
        Task<int> GetTotalCustomersAsync();
    }
}
