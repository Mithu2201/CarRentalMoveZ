using CarRentalMoveZ.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarRentalMoveZ.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Faq> Faqs { get; set; }



    }
}
