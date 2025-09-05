using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Mappings
{
    public class PaymentMapper
    {
        public static Payment ToPayment(PaymentViewModel viewModel)
        {
            return new Payment
            {
                BookingId = viewModel.BookingId,
                Amount = viewModel.Amount,
                PaymentDate = DateTime.Now,
                PaymentMethod = viewModel.PaymentMethod,
                Status = "Paid"
            };
        }

        public static IEnumerable<PaymentDTO> ToDTOList(IEnumerable<Payment> payments)
        {
            if (payments == null)
                return null;

            return payments
                .Where(payment => payment != null && payment.Booking != null)
                .Select(payment => new PaymentDTO
                {
                    PaymentId = payment.PaymentId,
                    BookingId = payment.BookingId,
                    Amount = payment.Amount,
                    PaymentDate = payment.PaymentDate,
                    PaymentMethod = payment.PaymentMethod,
                    Status = payment.Status,

                    // Assuming you want to flatten related Booking info:
                    BookingStartDate = payment.Booking.StartDate,
                    BookingEndDate = payment.Booking.EndDate,
                });
        }


    }
}
