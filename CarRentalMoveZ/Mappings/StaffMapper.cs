using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Mappings
{
    public class StaffMapper
    {
        public static IEnumerable<StaffDTO> ToDTOList(IEnumerable<Staff> staffs)
        {
            if (staffs == null)
                return null;

            return staffs
                .Where(staff => staff != null && staff.User != null)
                .Select(staff => new StaffDTO
                {
                    StaffId = staff.StaffId,
                    Name = staff.User.Name,
                    Email = staff.User.Email,
                    Role = staff.User.Role,
                    PhoneNumber = staff.User.PhoneNumber
                });
        }


        // Converts Staff entity to StaffViewModel
        public static StaffViewModel ToStaffViewModel(Staff staff)
        {
            return new StaffViewModel
            {
                Id = staff.StaffId,
                UserId = staff.UserId,  // Important!
                Name = staff.User.Name,
                Email = staff.User.Email,  // If you want to show email as readonly
                PhoneNumber = staff.User.PhoneNumber,
                DateOfBirth = staff.User.DateOfBirth,
                Gender = staff.User.Gender,
                Role = staff.Designation
            };
        }

        // Converts StaffViewModel to Staff entity (without changing Email)
        public static Staff ToStaffEntity(StaffViewModel model, User user)
        {
            return new Staff
            {
                StaffId = model.Id,
                UserId = user.UserId,  // Link staff to correct user
                Designation = model.Role,
                Department = "General",
                User = user
            };
        }

        // Converts StaffViewModel to User entity (without password and Email)
        public static User ToUserEntity(StaffViewModel model, User user)
        {
            return new User
            {
                UserId = user.UserId,
                Name = model.Name,
                Email = model.Email,
                Password = user.Password, // Retain existing password
                PhoneNumber = model.PhoneNumber,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                Role = model.Role
            };
        }
    }
}
