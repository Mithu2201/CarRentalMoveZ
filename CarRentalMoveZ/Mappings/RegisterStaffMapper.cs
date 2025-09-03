using CarRentalMoveZ.Models;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Mappings
{
    public class RegisterStaffMapper
    {

        public static User ToUserEntity(RegisterStaffViewModel model, string hashedPassword)
        {
            return new User
            {
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = hashedPassword,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,

                Role = model.Role // Admin or Staff
            };
        }

        public static Staff ToStaffEntity(RegisterStaffViewModel model, User user)
        {
            return new Staff
            {
                Designation = model.Role,
                Department = "General", // Default department, can be modified later
                UserId = user.UserId, // Will be set after User entity is created and ID is generated
                User = user
                // No need to set StaffId, it will be auto-generated
            };
        }

    }
}
