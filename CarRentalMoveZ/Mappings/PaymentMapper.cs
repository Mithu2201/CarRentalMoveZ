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

    }
}
