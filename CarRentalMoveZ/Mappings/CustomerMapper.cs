using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;

namespace CarRentalMoveZ.Mappings
{
    public class CustomerMapper
    {
        public static IEnumerable<CustomerDTO> ToDTOList(IEnumerable<Customer> customers)
        {
            if (customers == null)
                return Enumerable.Empty<CustomerDTO>();

            return customers
                .Where(customer => customer != null && customer.User != null)
                .Select(customer => new CustomerDTO
                {
                    CustomerId = customer.CustomerId,
                    Name = customer.User.Name,
                    Email = customer.User.Email,
                    PhoneNumber = customer.User.PhoneNumber,
                    /*Address = customer.Address*/ // Uncomment if needed
                });
        }

        public static CustomerDTO ToDTO(Customer customer)
        {
            if (customer == null) return null;

            return new CustomerDTO
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                
            };
        }

    }
}
