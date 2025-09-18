using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface IDriverService
    {
        

        IEnumerable<DriverDTO> GetAllDriver();

        DriverDTO Getbyid(int id);

        IEnumerable<DriverDTO> GetAvailableDrivers();
        void SetDriverOnDuty(int driverId);

        public void SetDriverOffDuty(int driverId);

        public void Update(DriverViewModel vm);

        void Delete(int driverId);

        DriverViewModel GetDriverViewModelById(int id);
    }
}
