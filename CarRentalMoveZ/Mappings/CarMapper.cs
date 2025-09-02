using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.ViewModels;

public class CarMapper
{
    // Map CarViewModel to Car (for saving/updating in the database)
    public static Car MapToEntity(CarViewModel viewModel)
    {
        return new Car
        {
            CarId = viewModel.CarId,
            CarName = viewModel.CarName,
            Brand = viewModel.Brand,
            Model = viewModel.Model,
            Year = viewModel.Year,
            PricePerDay = viewModel.PricePerDay,
            Status = viewModel.Status,
            ImgURL = viewModel.ImgURL
        };
    }

    // Map Car to CarViewModel (for displaying data in the view)
    public static CarViewModel MapToViewModel(Car car)
    {
        return new CarViewModel
        {
            CarId = car.CarId,
            CarName = car.CarName,
            Brand = car.Brand,
            Model = car.Model,
            Year = car.Year,
            PricePerDay = car.PricePerDay,
            Status = car.Status,
            ImgURL = car.ImgURL
        };
    }

    // New mapping: Entity -> DTO
    public static IEnumerable<CarDTO> ToDtoList(IEnumerable<Car> cars)
    {
        return cars.Select(c => new CarDTO
        {
            CarId = c.CarId,
            CarName = c.CarName,        
            Brand = c.Brand,
            Model = c.Model,
            Year = c.Year,
            PricePerDay = c.PricePerDay,
            Status = c.Status,
            ImgURL = c.ImgURL        
        });
    }


}
