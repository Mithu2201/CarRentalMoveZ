using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface IBookingService
    {
        int CreateBooking(BookingViewModel model);

        IEnumerable<BookingDTO> GetAllBookings();

        IEnumerable<BookingDTO> GetBookingsByUserId(int userId);

        BookingDetailsViewModel GetBookingById(int id);


        void UpdateBooking(BookingDetailsViewModel model);

        IEnumerable<BookingDetailsViewModel> GetAllBookingsDetail();

    }
}
