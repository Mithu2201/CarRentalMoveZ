using CarRentalMoveZ.Data;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRentalMoveZ.Repository.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.Include(c => c.User).ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customers
                .Include(c => c.User)
                .FirstOrDefault(c => c.CustomerId == id);
        }

        public Customer GetByUserId(int userId)
        {
            return _context.Customers
                .Include(c => c.User)
                .FirstOrDefault(c => c.UserId == userId);
        }
    }
}