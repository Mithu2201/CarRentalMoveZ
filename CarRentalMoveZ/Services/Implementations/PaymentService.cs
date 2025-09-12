using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Mappings;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.Repository.Interfaces;
using CarRentalMoveZ.Services.Interfaces;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public void addPayment(PaymentViewModel paymentViewModel)
        {
            Payment payment = PaymentMapper.ToPayment(paymentViewModel);
            _paymentRepository.AddPayment(payment);


        }

        public IEnumerable<PaymentDTO> GetAllPayments()
        {
            var payments = _paymentRepository.GetAllPayments();
            return PaymentMapper.ToDTOList(payments);
        }

        public IEnumerable<PaymentDTO> GetPaymentsByUserId(int userId)
        {
            var payments = _paymentRepository.GetPaymentsByUserId(userId);
            return PaymentMapper.ToDTOList(payments);
        }

        public void UpdatePayment(BookingDetailsViewModel model)
        {
            // Fetch existing booking
            var existingPayment = _paymentRepository.GetPaymentByBookingId(model.BookingId);
            if (existingPayment == null)
            {
                throw new Exception("Payment not found");
            }
         

            existingPayment.Amount = model.PaymentAmount;
            existingPayment.PaymentDate = model.PaymentDate ?? existingPayment.PaymentDate; // retain old date if null
            existingPayment.PaymentMethod = model.PaymentMethod ?? existingPayment.PaymentMethod; // retain old method if null
            existingPayment.Status = model.PaymentStatus ?? existingPayment.Status; // retain old status if null
         
            _paymentRepository.Update(existingPayment);
        }
    }
}
