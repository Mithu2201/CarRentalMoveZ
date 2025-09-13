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
                StartDate = vm.StartDate.Value,
                EndDate = vm.EndDate.Value,
                Days = vm.Days,
                Amount = vm.Amount,
                Status = "Pending",
                DriverStatus = vm.DriverStatus
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
                CarModel = booking.Car?.Model,
                
            };
        }

        public static IEnumerable<BookingDTO> ToDTOList(IEnumerable<Booking> bookings)
        {
            if (bookings == null)
            { 
            return null;
            }

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
                    CarModel = b.Car.Model,
                    DriverStatus = b.DriverStatus
                });
        }

        public static BookingDetailsViewModel ToDetailsViewModel(Booking booking, Payment payment)
        {
            if (booking == null) return null;

            return new BookingDetailsViewModel
            {
                BookingId = booking.BookingId,
                CarId = booking.CarId,
                CustomerId = booking.CustomerId,
                Location = booking.Location,
                BookingStatus = booking.Status,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Days = booking.Days,
                Amount = booking.Amount,
                DriverStatus = booking.DriverStatus,
                DriverId = booking.DriverId,

                CarName = booking.Car?.CarName ?? "",
                ImgURL = booking.Car?.ImgURL ?? "",
                PricePerDay = booking.Car?.PricePerDay ?? 0m,

                CustomerName = booking.Customer?.Name ?? "",
                PhoneNumber = booking.Customer?.PhoneNumber ?? "",

                IsPaid = payment != null &&
                (payment.Status == "Paid" || payment.Status == "Pending to refund" || payment.Status=="Refunded"),

                PaymentDate = payment?.PaymentDate,
                PaymentMethod = payment?.PaymentMethod,
                PaymentAmount = payment?.Amount ?? 0m,
                PaymentStatus = payment?.Status ?? "Pending"
            };
        }

        // Map BookingDetailsViewModel → Booking entity
        public static Booking ToEntity(BookingDetailsViewModel vm)
        {
            if (vm == null) return null;

            return new Booking
            {
                BookingId = vm.BookingId,
                CarId = vm.CarId,
                CustomerId = vm.CustomerId,
                Location = vm.Location,
                Status = vm.BookingStatus,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                Days = vm.Days,
                Amount = vm.Amount,
                DriverStatus= vm.DriverStatus
            };
        }


    }
}

