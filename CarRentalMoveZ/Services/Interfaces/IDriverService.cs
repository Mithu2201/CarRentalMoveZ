using CarRentalMoveZ.DTOs;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface IDriverService
    {
        

        IEnumerable<DriverDTO> GetAllDriver();
    }
}
