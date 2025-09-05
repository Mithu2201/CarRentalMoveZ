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
    }
}
