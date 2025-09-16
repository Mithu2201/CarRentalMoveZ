using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface IDriverService
    {
        

        IEnumerable<DriverDTO> GetAllDriver();

        DriverDTO Getbyid(int id);

        IEnumerable<DriverDTO> GetAvailableDrivers();
        void SetDriverOnDuty(int driverId);

        public void SetDriverOffDuty(int driverId);
    }
}
