using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface IStaffService
    {
        IEnumerable<StaffDTO> GetAllStaff();

        StaffViewModel GetById(int id);

        void Update(StaffViewModel model);
    }
}
