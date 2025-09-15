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
        public async Task<List<(string Hour, decimal Revenue)>> GetHourlyRevenueAsync(DateTime date)
        {
            var result = await _context.Payments
                .Where(p => p.Status == "Paid" && p.PaymentDate.Date == date.Date)
                .GroupBy(p => p.PaymentDate.Hour)
                .Select(g => new
                {
                    Hour = g.Key,
                    Revenue = g.Sum(x => x.Amount)
                })
                .OrderBy(x => x.Hour)
                .ToListAsync();

            // Convert to tuple after querying
            var hourlyRevenue = result
                .Select(x => (
                    Hour: $"{x.Hour}:00", // format as "10:00", "14:00"
                    Revenue: x.Revenue
                ))
                .ToList();

            return hourlyRevenue;
        }


        public async Task<(int Booked, int Pending, int Cancelled)> GetBookingStatusCountsAsync()
        {
            var booked = await _context.Bookings.CountAsync(b => b.Status == "Assigned");
            var pending = await _context.Bookings.CountAsync(b => b.Status == "Pending");
            var cancelled = await _context.Bookings.CountAsync(b => b.Status == "Cancelled");

            return (booked, pending, cancelled);
        }

        public async Task<List<(string Hour, int Count)>> GetHourlyBookingCountsAsync(DateTime date)
        {
            var result = await _context.Bookings
                .Where(b => b.StartDate.Date == date.Date) // bookings for the given day
                .GroupBy(b => b.StartDate.Hour)            // group by hour (0-23)
                .Select(g => new { Hour = g.Key, Count = g.Count() })
                .OrderBy(x => x.Hour)
                .ToListAsync();

            // Convert to string format "09:00", "14:00"
            return result.Select(x => ($"{x.Hour:00}:00", x.Count)).ToList();
        }

        public async Task<(int Available, int Booked, int Pending)> GetCarStatusCountsAsync()
        {
            var availableCar = await _context.Cars.CountAsync(c => c.Status == "Available");
            var bookedCar = await _context.Cars.CountAsync(c => c.Status == "Booked");
            var pendingCar = await _context.Cars.CountAsync(c => c.Status == "Pending");

            return (availableCar, bookedCar, pendingCar);
        }

    }

}
