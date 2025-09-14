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

        public async Task<List<(string Month, decimal Revenue)>> GetMonthlyRevenueAsync()
        {
            var result = await _context.Bookings
            .Join(
            _context.Payments.Where(p => p.Status == "Paid"),
            b => b.BookingId,
            p => p.BookingId,
            (b, p) => new { p.PaymentDate, p.Amount }
            )
            .GroupBy(x => x.PaymentDate.Month)
        .Select(g => new { Month = g.Key, Revenue = g.Sum(x => x.Amount) })
        .OrderBy(x => x.Month)
        .ToListAsync(); // <-- EF Core materializes anonymous type

            // Convert to tuple after querying
            var monthlyRevenue = result
                .Select(x => (
                    Month: System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(x.Month),
                    Revenue: x.Revenue
                ))
                .ToList();

            return monthlyRevenue;
        }

        public async Task<(int Booked, int Pending, int Cancelled)> GetBookingStatusCountsAsync()
        {
            var booked = await _context.Bookings.CountAsync(b => b.Status == "Assigned");
            var pending = await _context.Bookings.CountAsync(b => b.Status == "Pending");
            var cancelled = await _context.Bookings.CountAsync(b => b.Status == "Cancelled");

            return (booked, pending, cancelled);
        }
    }

}
