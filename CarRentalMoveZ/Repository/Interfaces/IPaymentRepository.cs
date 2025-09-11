using CarRentalMoveZ.Models;

namespace CarRentalMoveZ.Repository.Interfaces
{
    public interface IPaymentRepository
    {
        void AddPayment(Payment payment);

        IEnumerable<Payment> GetAllPayments();

        IEnumerable<Payment> GetPaymentsByUserId(int userId);
        Payment GetPaymentByBookingId(int bookingId);

    }
}
