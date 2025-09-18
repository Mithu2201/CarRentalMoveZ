using CarRentalMoveZ.Models;

namespace CarRentalMoveZ.Repository.Interfaces
{
    public interface IDriverRepository
    {
        IEnumerable<Driver> GetAll();

        void Add(Models.Driver driver);

        Driver Getbyid(int id);

        IEnumerable<Driver> GetActiveDrivers();
       
        void Update(Driver driver);

        void UpdateDriverStatusBasedOnLastBooking();

        void Delete(int id);

    }
}
