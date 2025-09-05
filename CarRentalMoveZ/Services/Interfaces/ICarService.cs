using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface ICarService
    {
        void AddCar(CarViewModel car);

        IEnumerable<CarDTO> GetAll();

        IEnumerable<CarDTO> GetAllAvailable();

        void UpdateCar(CarViewModel car);

        CarViewModel GetCarById(int id);

        void DeleteCar(int id);
    }
}
