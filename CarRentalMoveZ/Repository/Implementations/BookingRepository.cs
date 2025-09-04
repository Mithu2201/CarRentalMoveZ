using CarRentalMoveZ.Data;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.Repository.Interfaces;

namespace CarRentalMoveZ.Repository.Implementations
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();


        }
    }
}
