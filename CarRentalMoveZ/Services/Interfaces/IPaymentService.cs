using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface IPaymentService
    {
        void addPayment(PaymentViewModel paymentViewModel);
    }
}
