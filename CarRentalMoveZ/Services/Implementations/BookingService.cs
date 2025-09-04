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
       
        public BookingService(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public int CreateBooking(BookingViewModel model)
        {
            // Map ViewModel → Entity using Mapper
            Booking booking = BookingMapper.ToEntity(model);

            // Save to repository
            var id=_bookingRepo.Add(booking);
            return id;
        }
    }
}
