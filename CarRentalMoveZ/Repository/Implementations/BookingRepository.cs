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

        public IEnumerable<Booking> GetBookingsByUserId(int userId)
        {
            return _context.Bookings
                           .Include(b => b.Car)
                           .Include(b => b.Customer)
                           .Where(b => b.Customer.UserId == userId) // Assuming Customer has UserId FK
                           .ToList();
        }

        public Booking GetBooking(int id)
        {
            return _context.Bookings
                           .Include(b => b.Car)
                           .Include(b => b.Customer)
                           .FirstOrDefault(b => b.BookingId == id);
        }


        public void Update(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

        public IEnumerable<Booking> GetBookingsByCar(int carId)
        {
            return _context.Bookings
                .Where(b => b.CarId == carId && b.Status != "Cancelled")
                .ToList();
        }

    }
}
