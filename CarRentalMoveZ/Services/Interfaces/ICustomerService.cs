using CarRentalMoveZ.DTOs;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDTO> GetAllCustomer();
    }
}
