using CarRentalMoveZ.Models;

namespace CarRentalMoveZ.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);

        IEnumerable<Customer> GetAll();
        Customer GetById(int id);

        Customer GetByUserId(int userId);
    }
}
