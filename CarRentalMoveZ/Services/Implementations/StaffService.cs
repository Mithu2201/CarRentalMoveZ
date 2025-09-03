using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Mappings;
using CarRentalMoveZ.Repository.Interfaces;
using CarRentalMoveZ.Services.Interfaces;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Implementations
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepo;
        private readonly IUserRepository _userRepo;

        public StaffService(IStaffRepository staffRepository, IUserRepository userRepository)
        {
            _staffRepo = staffRepository;
            _userRepo = userRepository;
        }

        public IEnumerable<StaffDTO> GetAllStaff()
        {

            var staffs = _staffRepo.GetAll();


            return StaffMapper.ToDTOList(staffs);
        }

        public StaffViewModel GetById(int id) => StaffMapper.ToStaffViewModel(_staffRepo.GetById(id));

        public void Update(StaffViewModel model)
        {
            // Fetch the existing User entity (tracked by EF)
            var user = _userRepo.GetByEmail(model.Email);

            if (user == null)
            {
                // Handle error: user not found


                throw new Exception("User not found");
            }

            // Update the existing User entity's properties directly
            user.Name = model.Name;
            user.PhoneNumber = model.PhoneNumber;
            user.DateOfBirth = model.DateOfBirth;
            user.Gender = model.Gender;
            user.Role = model.Role;
            // Don't update Email or Password unless explicitly changed

            // Similarly fetch the Staff entity or update its properties
            var staff = _staffRepo.GetById(model.Id);
            if (staff == null)
            {
                // Handle error: staff not found
                throw new Exception("Staff not found");
            }
            staff.Designation = model.Role;    // or whatever mapping you want
            staff.User = user;                  // keep navigation property updated

            // Now update using tracked entities, no new object creation needed
            _staffRepo.Update(user, staff);
        }

    }
}
