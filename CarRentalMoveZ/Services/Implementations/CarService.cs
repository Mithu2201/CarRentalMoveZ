using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Repository.Interfaces;
using CarRentalMoveZ.Services.Interfaces;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public void AddCar(CarViewModel carViewModel)
        {
            var car = CarMapper.MapToEntity(carViewModel);
            _carRepository.AddCar(car);
        }


        public IEnumerable<CarDTO> GetAll()
        {
            var cars = _carRepository.GetAll();
            return CarMapper.ToDtoList(cars);
        }

        public IEnumerable<CarDTO> GetAllAvailable()
        {
            var availablecars = _carRepository.GetAllAvailable();
            return CarMapper.ToDtoList(availablecars);

        }

        public CarViewModel GetCarById(int id)
        {
            var car = _carRepository.GetCarById(id);
            return CarMapper.MapToViewModel(car);
        }

        public void UpdateCar(CarViewModel carViewModel)
        {
            var car = CarMapper.MapToEntity(carViewModel);
            _carRepository.UpdateCar(car);
        }

        public void DeleteCar(int id)
        {
            var car = _carRepository.GetCarById(id);
            if (car != null)
            {
                _carRepository.DeleteCar(car);
            }
        }
    }
}
