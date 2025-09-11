using CarRentalMoveZ.Models;

namespace CarRentalMoveZ.Repository.Interfaces
{
    public interface IBookingRepository
    {
        int Add(Booking booking);

        IEnumerable<Booking> GetAllBookings();
        IEnumerable<Booking> GetBookingsByUserId(int userId);
        Booking GetBooking(int id);


        void Update(Booking booking);

    }
}
