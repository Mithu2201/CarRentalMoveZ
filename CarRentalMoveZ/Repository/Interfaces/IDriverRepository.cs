using CarRentalMoveZ.Models;

namespace CarRentalMoveZ.Repository.Interfaces
{
    public interface IDriverRepository
    {
        IEnumerable<Driver> GetAll();

        void Add(Models.Driver driver);

    }
}
