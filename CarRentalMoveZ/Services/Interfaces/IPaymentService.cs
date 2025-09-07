using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface IPaymentService
    {
        void addPayment(PaymentViewModel paymentViewModel);

        IEnumerable<PaymentDTO> GetAllPayments();

        IEnumerable<PaymentDTO> GetPaymentsByUserId(int userId);
    }
}
