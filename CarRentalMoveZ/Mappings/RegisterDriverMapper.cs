using CarRentalMoveZ.Models;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Mappings
{
    public class RegisterDriverMapper
    {
        public static User ToUserEntity(RegisterDriverViewModel model, string hashedPassword)
        {
            return new User
            {
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = hashedPassword,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                Role = "Driver" // Always Driver
            };
        }

        public static Driver ToDriverEntity(RegisterDriverViewModel model, User user)
        {
            return new Driver
            {
                UserId = user.UserId, // set after User is saved
                User = user,
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                LicenseNo = model.LicenseNo,
                Gender=model.Gender,
                DateOfBirth=model.DateOfBirth,
                Status = "Active" // Default status
            };
        }
    }
}
