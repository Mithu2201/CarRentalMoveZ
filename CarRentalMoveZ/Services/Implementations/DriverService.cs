using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Mappings;
using CarRentalMoveZ.Repository.Interfaces;
using CarRentalMoveZ.Services.Interfaces;

namespace CarRentalMoveZ.Services.Implementations
{
    public class DriverService: IDriverService
    {
     
        private readonly IDriverRepository driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            this.driverRepository = driverRepository;
        }

       
        public IEnumerable<DriverDTO> GetAllDriver()
        {

            var drivers = driverRepository.GetAll();

            return DriversMapper.ToDTOList(drivers);
        }

        public DriverDTO Getbyid(int id)
        {
            var driver = driverRepository.Getbyid(id);
            return DriversMapper.ToDTO(driver);
        }

        public void SetDriverOnDuty(int driverId)
        {
            var driver = driverRepository.Getbyid(driverId);
            if (driver == null) return;

            driver.Status = "On Duty";
            driverRepository.Update(driver);
        }
        public void SetDriverOffDuty(int driverId)
        {
            var driver = driverRepository.Getbyid(driverId);
            if (driver == null) return;

            driver.Status = "Active";
            driverRepository.Update(driver);
        }

        public IEnumerable<DriverDTO> GetAvailableDrivers()
        {
            var drivers = driverRepository.GetActiveDrivers();
            return DriversMapper.ToAvailableDTOList(drivers);
        }

    }
}
