using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Mappings;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.Repository.Interfaces;
using CarRentalMoveZ.Services.Interfaces;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IPaymentRepository _paymentRepo;

        public BookingService(IBookingRepository bookingRepo,IPaymentRepository paymentRepo)
        {
            _bookingRepo = bookingRepo;
            _paymentRepo = paymentRepo;
        }

        public int CreateBooking(BookingViewModel model)
        {
            // Map ViewModel → Entity using Mapper
            Booking booking = BookingMapper.ToEntity(model);

            // Save to repository
            var id=_bookingRepo.Add(booking);
            return id;
        }

        public IEnumerable<BookingDTO> GetAllBookings()
        {

            var bookings = _bookingRepo.GetAllBookings();


            return BookingMapper.ToDTOList(bookings);
        }
        public IEnumerable<BookingDTO> GetBookingsByUserId(int userId)
        {
            var bookings = _bookingRepo.GetBookingsByUserId(userId);
            return BookingMapper.ToDTOList(bookings);
        }

        public BookingDetailsViewModel GetBookingById(int id)
        {
            var booking = _bookingRepo.GetBooking(id);
            var payment = _paymentRepo.GetPaymentByBookingId(id);
            if (booking == null)
            {
                return null; // Or throw an exception, based on your error handling strategy
            }
            return BookingMapper.ToDetailsViewModel(booking,payment);
        }

        public IEnumerable<BookingDetailsViewModel> GetAllBookingsDetail()
        {
            var bookings = _bookingRepo.GetAllBookings();
            var bookingDetailsList = new List<BookingDetailsViewModel>();
            foreach (var booking in bookings)
            {
                var payment = _paymentRepo.GetPaymentByBookingId(booking.BookingId);
                var bookingDetails = BookingMapper.ToDetailsViewModel(booking, payment);
                bookingDetailsList.Add(bookingDetails);
            }
            return bookingDetailsList;
        }

        public void UpdateBooking(BookingDetailsViewModel model)
        {
            // Fetch existing booking
            var existingBooking = _bookingRepo.GetBooking(model.BookingId);
            if (existingBooking == null)
            {
                throw new Exception("Booking not found");
            }
            // Update fields
            existingBooking.Location = model.Location;
            existingBooking.StartDate = model.StartDate;
            existingBooking.EndDate = model.EndDate;
            existingBooking.Days = model.Days;
            existingBooking.Amount = model.Amount;
            existingBooking.Status = model.BookingStatus;
            // Save changes
            _bookingRepo.Update(existingBooking);
        }

    }
}
