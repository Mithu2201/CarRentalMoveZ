using CarRentalMoveZ.Models;

namespace CarRentalMoveZ.Repository.Interfaces
{
    public interface IPaymentRepository
    {
        void AddPayment(Payment payment);
    }
}
