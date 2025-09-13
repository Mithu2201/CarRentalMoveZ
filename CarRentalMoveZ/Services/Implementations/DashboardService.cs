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
            return new DashboardDTO
            {
                TotalBookings = await _repo.GetTotalBookingsAsync(),
                TotalRevenue = await _repo.GetTotalRevenueAsync(),
                TotalCars = await _repo.GetTotalCarsAsync(),
                AvailableCars = await _repo.GetAvailableCarsAsync(),
                TotalCustomers = await _repo.GetTotalCustomersAsync()
            };
        }
    }
}
