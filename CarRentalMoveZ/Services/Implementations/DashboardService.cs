using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Repository.Interfaces;
using CarRentalMoveZ.Services.Interfaces;

namespace CarRentalMoveZ.Services.Implementations
{
    public class DashboardService : IDashboardService
    {

        private readonly IDashboardRepository _repo;

        public DashboardService(IDashboardRepository repo)
        {
            _repo = repo;
        }
        public async Task<DashboardDTO> GetDashboardDataAsync()
        {
            // First, create the basic dashboard object with totals
            var dashboard = new DashboardDTO
            {
                TotalBookings = await _repo.GetTotalBookingsAsync(),
                TotalRevenue = await _repo.GetTotalRevenueAsync(),
                TotalCars = await _repo.GetTotalCarsAsync(),
                AvailableCars = await _repo.GetAvailableCarsAsync(),
                TotalCustomers = await _repo.GetTotalCustomersAsync()
            };

            // Earnings chart
            var monthlyRevenue = await _repo.GetMonthlyRevenueAsync();
            dashboard.EarningsMonths = monthlyRevenue.Select(x => x.Month).ToList();
            dashboard.EarningsRevenue = monthlyRevenue.Select(x => x.Revenue).ToList();

            // Rent Status chart
            var (booked, pending, cancelled) = await _repo.GetBookingStatusCountsAsync();
            dashboard.BookedCount = booked;
            dashboard.PendingCount = pending;
            dashboard.CancelledCount = cancelled;

            return dashboard;
        }

    }
}
