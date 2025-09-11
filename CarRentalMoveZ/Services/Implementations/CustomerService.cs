using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Mappings;
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

        public CustomerDTO GetCustomerById(int id)
        {
            var customer = _customerRepo.GetById(id);
            return CustomerMapper.ToDTO(customer);
        }

        public CustomerDTO GetCustomerByUserId(int userId)
        {
            var customer = _customerRepo.GetByUserId(userId);
            return CustomerMapper.ToDTO(customer);
        }

        public int  GetCustomerUserId(int customerId)
        {
            var customer = _customerRepo.GetById(customerId);
            return customer.UserId;
        }
    }
}
