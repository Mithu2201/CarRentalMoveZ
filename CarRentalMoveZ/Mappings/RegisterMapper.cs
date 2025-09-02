using CarRentalMoveZ.Models;
using CarRentalMoveZ.ViewModels;


namespace CarRentalMoveZ.Mappings
{
    public static class RegisterMapper
    {
        public static User ToUserEntity(RegisterViewModel model, string hashedPassword)
        {
            return new User
            {
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = hashedPassword,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,

                Role = "Customer"
            };
        }

        public static Customer ToCustomerEntity(RegisterViewModel model, string hashedPassword)
        {
            return new Customer
            {
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = hashedPassword,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,

                Role = "Customer"
            };
        }
    }
}
