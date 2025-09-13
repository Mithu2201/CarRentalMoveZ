using CarRentalMoveZ.Data;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRentalMoveZ.Repository.Implementations
{
    public class DriverRepository: IDriverRepository
    {
        private readonly AppDbContext _context;
        public DriverRepository(AppDbContext context)
        {
            _context = context;
        }
        // Implement CRUD operations for Driver entity here

        public void Add(Models.Driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();
        }

        public IEnumerable<Driver> GetAll()
        {
            return _context.Drivers.Include(d => d.User).ToList();
        }

        public Driver Getbyid(int id)
        {
            return _context.Drivers
                .Include(d => d.User)
                .FirstOrDefault(d => d.DriverId == id);

        }


    }
}
