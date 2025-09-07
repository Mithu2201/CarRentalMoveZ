using CarRentalMoveZ.Data;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.Repository.Interfaces;

namespace CarRentalMoveZ.Repository.Implementations
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Cars.ToList();
        }

        public IEnumerable<Car> GetAllAvailable()
        {
            return _context.Cars
                .Where(car => car.Status == "Available")
                .ToList();
        }


        public Car GetCarById(int id)
        {
            return _context.Cars.FirstOrDefault(c => c.CarId == id);
        }

        public void UpdateCar(Car car)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
        }

        public void DeleteCar(Car car) 
        {
           _context.Cars.Remove(car);
           _context.SaveChanges();

        }
    }
}
