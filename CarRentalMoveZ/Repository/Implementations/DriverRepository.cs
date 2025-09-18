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

        public IEnumerable<Driver> GetActiveDrivers()
        {
            return _context.Drivers
                .Where(d => d.Status == "Active")
                .OrderBy(d => d.Name)
                .ToList();
        }

        public void Update(Driver driver)
        {
            _context.Drivers.Update(driver);
            _context.SaveChanges();
        }

        public void UpdateDriverStatusBasedOnLastBooking()
        {
            // Get all drivers
            var drivers = _context.Drivers.ToList();

            foreach (var driver in drivers)
            {
                // Get the latest assigned booking for this driver
                var lastBooking = _context.Bookings
                .Where(b => b.DriverId == driver.DriverId && b.Status == "Assigned")
                .OrderByDescending(b => b.StatusUpdatedAt ?? b.StartDate)
                .FirstOrDefault();


                if (lastBooking != null)
                {
                    // Check if the booking has already ended
                    bool bookingEnded = lastBooking.EndDate <= DateTime.Now;

                    // Special condition for "car-only" bookings:
                    // 1. Booking does not require a driver for the ride
                    // 2. Car needs to be delivered somewhere other than the office
                    // 3. The delivery/start time has already passed
                    bool specialCondition = lastBooking.DriverStatus == "Without Driver"
                                            && lastBooking.Location != "Office"
                                            && lastBooking.StartDate < DateTime.Now;

                    // Check if booking has ended
                    if (lastBooking.EndDate <= DateTime.Now || (lastBooking.DriverStatus== "Without Driver" && lastBooking.Location!="Office" && lastBooking.StartDate< DateTime.Now))
                    {
                        // Update driver status to "Active" if not already
                        if (driver.Status != "Active")
                        {
                            driver.Status = "Active";
                        }
                    }
                }
            }

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var driver = _context.Drivers
                                 .Include(d => d.User)
                                 .FirstOrDefault(d => d.DriverId == id);

            if (driver != null)
            {
                // Remove Driver entity
                _context.Drivers.Remove(driver);

                // Also remove associated User entity (if exists)
                if (driver.User != null)
                {
                    _context.Users.Remove(driver.User);
                }

                _context.SaveChanges();
            }
        }

    }
}
