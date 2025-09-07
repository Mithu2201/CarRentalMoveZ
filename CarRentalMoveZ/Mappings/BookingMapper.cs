using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Mappings
{
    public static class BookingMapper
    {
        public static Booking ToEntity(BookingViewModel vm)
        {
            return new Booking
            {
                BookingId = vm.BookingId,
                CarId = vm.CarId,
                CustomerId = vm.CustomerId,
                Location = vm.Location,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                Days = vm.Days,
                Amount = vm.Amount,
                Status = "Pending"
            };
        }

        public static BookingDTO ToBookingDTO(Booking booking)
        {
            return new BookingDTO
            {
                BookingId = booking.BookingId,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Status = booking.Status,
                Location = booking.Location,
                Payment = booking.Amount, // Assuming Amount is the payment
                CustomerName = booking.Customer?.Name,
                CarModel = booking.Car?.Model
            };
        }

        public static IEnumerable<BookingDTO> ToDTOList(IEnumerable<Booking> bookings)
        {
            if (bookings == null)
                return null;

            return bookings
                .Where(b => b != null && b.Car != null && b.Customer != null)
                .Select(b => new BookingDTO
                {
                    BookingId = b.BookingId,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate,
                    Status = b.Status,
                    Location = b.Location,
                    Payment = b.Amount,
                    CustomerName = b.Customer.Name,
                    CarModel = b.Car.Model
                });
        }



    }
}

