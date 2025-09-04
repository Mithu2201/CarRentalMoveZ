using CarRentalMoveZ.Models;
using CarRentalMoveZ.Repository.Interfaces;
using CarRentalMoveZ.Data;

namespace CarRentalMoveZ.Repository.Implementations
{
    public class PaymentRepository: IPaymentRepository
    {
        private readonly AppDbContext _context;
        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }
    }
}
