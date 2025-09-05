using CarRentalMoveZ.Data;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRentalMoveZ.Repository.Implementations
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return booking.BookingId; // This now contains the generated ID
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _context.Bookings
                           .Include(b => b.Car)
                           .Include(b => b.Customer)
                           .ToList();
        }

    }
}
