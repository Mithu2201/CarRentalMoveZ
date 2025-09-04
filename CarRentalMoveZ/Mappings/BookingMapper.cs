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

    }
}

