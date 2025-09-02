using CarRentalMoveZ.Models;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Repository.Interfaces
{
    public interface ICarRepository
    {
        void AddCar(Car car);

        IEnumerable<Car> GetAll();

        void UpdateCar(Car car);

        Car GetCarById(int id);

        void DeleteCar(Car car);
    }
}
