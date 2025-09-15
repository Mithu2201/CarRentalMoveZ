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

            // Earnings chart (Hourly)
            var hourlyRevenue = await _repo.GetHourlyRevenueAsync(DateTime.Now);
            dashboard.EarningsHours = hourlyRevenue.Select(x => x.Hour).ToList();
            dashboard.EarningsRevenue = hourlyRevenue.Select(x => x.Revenue).ToList();

            // Rent Status chart
            var (booked, pending, cancelled) = await _repo.GetBookingStatusCountsAsync();
            dashboard.BookedCount = booked;
            dashboard.PendingCount = pending;
            dashboard.CancelledCount = cancelled;

            var today = DateTime.Today;
            var hourlyBookings = await _repo.GetHourlyBookingCountsAsync(today);

            dashboard.BookingHours = hourlyBookings.Select(x => x.Hour).ToList();
            dashboard.BookingCounts = hourlyBookings.Select(x => x.Count).ToList();

       
            // Car Status Pie Chart
            var (availablecar, bookedcar, pendingcar) = await _repo.GetCarStatusCountsAsync();
            dashboard.AvailableCarCount = availablecar;
            dashboard.BookedCarCount = bookedcar;
            dashboard.PendingCarCount = pendingcar;

            return dashboard;
        }

    }
}
