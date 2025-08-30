using CarRentalMoveZ.Models;

namespace CarRentalMoveZ.Repository.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetByEmail(string email);
        void Update(User user);
    }
}