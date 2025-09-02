using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface ICarService
    {
        void AddCar(CarViewModel car);

        IEnumerable<CarDTO> GetAll();

        void UpdateCar(CarViewModel car);

        CarViewModel GetCarById(int id);

        void DeleteCar(int id);
    }
}
