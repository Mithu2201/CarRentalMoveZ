using CarRentalMoveZ.Data;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.Repository.Interfaces;

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
    }
}