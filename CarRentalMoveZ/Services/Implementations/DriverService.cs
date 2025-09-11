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



    }
}
