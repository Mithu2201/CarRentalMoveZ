using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;

namespace CarRentalMoveZ.Repository.Interfaces
{
    public interface IPaymentRepository
    {
        void AddPayment(Payment payment);

        IEnumerable<Payment> GetAllPayments();

        IEnumerable<Payment> GetPaymentsByUserId(int userId);
        Payment GetPaymentByBookingId(int bookingId);

        Task<List<PaymentDTO>> GetLast5PaidPaymentsAsync();

        Task<List<PaymentDTO>> GetLast5CashPaymentsAsync(int customerId);

        void Update(Payment payment);

    }
}
