using CarRentalMoveZ.Models;

namespace CarRentalMoveZ.Repository.Interfaces
{
    public interface IStaffRepository
    {
        void Add(Staff staff);

        IEnumerable<Staff> GetAll();

        Staff GetById(int id);

        void Update(User user, Staff staff);

        void Delete(int id);
    }
}
