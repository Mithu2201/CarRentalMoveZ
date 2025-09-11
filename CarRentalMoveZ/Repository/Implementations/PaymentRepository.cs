using CarRentalMoveZ.Data;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<Payment> GetAllPayments()
        {
            return _context.Payments.Include(p => p.Booking).ToList();
        }

        public IEnumerable<Payment> GetPaymentsByUserId(int userId)
        {
            return _context.Payments
                .Include(p => p.Booking)
                    .ThenInclude(b => b.Customer) // ensure Customer is included
                .Where(p => p.Booking.Customer.UserId == userId)
                .ToList();
        }
        public Payment GetPaymentByBookingId(int bookingId)
        {
            return _context.Payments.FirstOrDefault(p => p.BookingId == bookingId);
        }


    }
}
