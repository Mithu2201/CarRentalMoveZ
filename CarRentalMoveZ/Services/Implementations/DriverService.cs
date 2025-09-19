using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Mappings;
using CarRentalMoveZ.Repository.Interfaces;
using CarRentalMoveZ.Services.Interfaces;
using CarRentalMoveZ.ViewModels;

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
        public DriverDTO GetbyUserid(int id)
        {
            var driver = driverRepository.GetByUserId(id);
            return DriversMapper.ToDTO(driver);
        }

        public DriverViewModel GetDriverViewModelById(int id)
        {
            var driver = driverRepository.Getbyid(id);
            if (driver == null) return null;

            return new DriverViewModel
            {
                DriverId = driver.DriverId,
                UserId = driver.UserId,
                Name = driver.Name,
                PhoneNumber = driver.PhoneNumber,
                Email = driver.Email,
                DateOfBirth = driver.DateOfBirth,
                Gender = driver.Gender,
                LicenseNo = driver.LicenseNo,

                Role = "Driver" // fixed role
            };
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

        public void Update(DriverViewModel vm)
        {
            var driver = driverRepository.Getbyid(vm.DriverId);
            if (driver == null) return;

            // Update properties
            driver.Name = vm.Name;
            driver.PhoneNumber = vm.PhoneNumber;
            driver.Email = vm.Email;
            driver.DateOfBirth = vm.DateOfBirth;
            driver.Gender = vm.Gender;
            driver.LicenseNo = vm.LicenseNo;


            // Role is fixed in entity as [NotMapped], no need to update

            driverRepository.Update(driver);
        }

        public void Delete(int driverId)
        {
            driverRepository.Delete(driverId);
        }



    }
}
