using CarRentalMoveZ.Data;
using CarRentalMoveZ.DTOs;
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

        public void Update(Payment payment)
        {
            _context.Payments.Update(payment);
            _context.SaveChanges();
        }


        public async Task<List<PaymentDTO>> GetLast5PaidPaymentsAsync()
        {
            return await _context.Payments
                .Where(p => p.Status == "Paid")
                .OrderByDescending(p => p.PaymentDate)
                .Take(5)
                .Select(p => new PaymentDTO
                {
                    PaymentId = p.PaymentId,
                    BookingId = p.BookingId,
                    BookingStartDate = p.Booking.StartDate,
                    BookingEndDate = p.Booking.EndDate,
                    Amount = p.Amount,
                    PaymentDate = p.PaymentDate,
                    PaymentMethod = p.PaymentMethod,
                    Status = p.Status
                })
                .ToListAsync();
        }

        public async Task<List<PaymentDTO>> GetLast5CashPaymentsAsync(int customerId)
        {
            return await _context.Payments
                .Include(p => p.Booking)
                .Where(p => p.Status == "Paid"
                            && p.PaymentMethod == "Cash"
                            && p.Booking.CustomerId == customerId)
                .OrderByDescending(p => p.PaymentDate)
                .Take(5)
                .Select(p => new PaymentDTO
                {
                    PaymentId = p.PaymentId,
                    BookingId = p.BookingId,
                    BookingStartDate = p.Booking.StartDate,
                    BookingEndDate = p.Booking.EndDate,
                    Amount = p.Amount,
                    PaymentDate = p.PaymentDate,
                    PaymentMethod = p.PaymentMethod,
                    Status = p.Status
                })
                .ToListAsync();
        }

    }
}
