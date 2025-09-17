using CarRentalMoveZ.Data;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRentalMoveZ.Repository.Implementations
{
    public class StaffRepository : IStaffRepository
    {
        private readonly AppDbContext _context;
        public StaffRepository(AppDbContext context)
        {
            _context = context;
        }


        public void Add(Staff staff)
        {
            _context.Staffs.Add(staff);
            _context.SaveChanges();
        }

        public IEnumerable<Staff> GetAll()
        {
            return _context.Staffs.Include(s => s.User).ToList();
        }


        public Staff GetById(int id)
        {
            return _context.Staffs
                           .Include(s => s.User)  // Include the related User entity
                           .FirstOrDefault(s => s.StaffId == id);  // Fetch by StaffId
        }



        public void Update(User user, Staff staff)
        {
            _context.Users.Update(user);
            _context.Staffs.Update(staff);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var staff = _context.Staffs.Include(s => s.User).FirstOrDefault(s => s.StaffId == id);
            if (staff != null)
            {
                // First remove the Staff entity
                _context.Staffs.Remove(staff);
                // Then remove the associated User entity
                if (staff.User != null)
                {
                    _context.Users.Remove(staff.User);
                }
                _context.SaveChanges();
            }


        }

    }
}