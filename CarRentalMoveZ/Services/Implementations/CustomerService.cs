using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Repository.Interfaces;
using CarRentalMoveZ.Services.Interfaces;


namespace CarRentalMoveZ.Services.Implementations
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepo;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepo = customerRepository;
        }
        public IEnumerable<CustomerDTO> GetAllCustomer()
        {
            var customers = _customerRepo.GetAll();
            return Mappings.CustomerMapper.ToDTOList(customers);
        }
    }
}
