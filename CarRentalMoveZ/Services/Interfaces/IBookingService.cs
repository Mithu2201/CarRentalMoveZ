using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface IBookingService
    {
        int CreateBooking(BookingViewModel model);

        IEnumerable<BookingDTO> GetAllBookings();

    }
}
