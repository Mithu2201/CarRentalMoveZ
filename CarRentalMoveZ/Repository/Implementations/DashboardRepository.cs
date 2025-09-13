using CarRentalMoveZ.Data;
using CarRentalMoveZ.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRentalMoveZ.Repository.Implementations
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly AppDbContext _context;

        public DashboardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalBookingsAsync()
        {
            return await _context.Bookings.CountAsync();
        }

        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await _context.Payments
                                 .Where(p => p.Status == "Paid")
                                 .SumAsync(p => p.Amount);
        }

        public async Task<int> GetTotalCarsAsync()
        {
            return await _context.Cars.CountAsync();
        }

        public async Task<int> GetAvailableCarsAsync()
        {
            return await _context.Cars.CountAsync(c => c.Status == "Available");
        }

        public async Task<int> GetTotalCustomersAsync()
        {
            return await _context.Customers.CountAsync();
        }
    }

}
