using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface IBookingService
    {
        int CreateBooking(BookingViewModel model);

        IEnumerable<BookingDTO> GetAllBookings();

        IEnumerable<BookingDTO> GetBookingsByUserId(int userId);

        BookingDetailsViewModel GetBookingById(int id);

        IEnumerable<Booking> GetBookingsForCar(int carId);
        void UpdateBooking(BookingDetailsViewModel model);

        IEnumerable<BookingDetailsViewModel> GetAllBookingsDetail();

        void CancelBooking(int bookingId);

    }
}
