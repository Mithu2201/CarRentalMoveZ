using CarRentalMoveZ.Models;

namespace CarRentalMoveZ.Repository.Interfaces
{
    public interface IBookingRepository
    {
        int Add(Booking booking);

        IEnumerable<Booking> GetAllBookings();

    }
}
