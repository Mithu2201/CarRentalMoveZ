using CarRentalMoveZ.Mappings;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.Repository.Interfaces;
using CarRentalMoveZ.Services.Interfaces;
using CarRentalMoveZ.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;


namespace CarRentalMoveZ.Services.Implementations
{
    public class RegisterService : IRegisterService
    {
        private readonly IUserRepository _userRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IStaffRepository _staffRepo;
        private readonly IDriverRepository _driverRepo;
        private readonly PasswordHasher<User> _passwordHasher;


        public RegisterService(IUserRepository userRepo,ICustomerRepository customerRepo, IStaffRepository staffRepo, IDriverRepository driverRepo)
        {
            _userRepo = userRepo;
            _customerRepo = customerRepo;
            _passwordHasher = new PasswordHasher<User>();
            _staffRepo = staffRepo;
            _driverRepo = driverRepo;
        }

        public void Register(RegisterViewModel model)
        {
            var user = RegisterMapper.ToUserEntity(model, null);

            // Hash password with Identity PasswordHasher
            user.Password = _passwordHasher.HashPassword(user, model.Password);
            _userRepo.Add(user);

            var customer = RegisterMapper.ToCustomerEntity(model, user.UserId);
            _customerRepo.Add(customer);

        }

        public bool RegisterStaff(RegisterStaffViewModel model)
        {
            var checkuser = _userRepo.GetByEmail(model.Email);
            if (checkuser != null || model.Email == "admin@movez.com")
            {
                return false;
            }
            else
            {
                var user = RegisterStaffMapper.ToUserEntity(model, null);

                // Hash password with Identity PasswordHasher
                user.Password = _passwordHasher.HashPassword(user, model.Password);


                _userRepo.Add(user);

                var staff = RegisterStaffMapper.ToStaffEntity(model, user);

                _staffRepo.Add(staff);

                return true;
            }
        }
        public 
            
            bool RegisterDriver(RegisterDriverViewModel model)
        {
            var checkuser = _userRepo.GetByEmail(model.Email);
            if (checkuser != null || model.Email == "admin@movez.com")
            {
                return false;
            }
            else
            {
                var user = RegisterDriverMapper.ToUserEntity(model, null);

                // Hash password with Identity PasswordHasher
                user.Password = _passwordHasher.HashPassword(user, model.Password);


                _userRepo.Add(user);

                var driver = RegisterDriverMapper.ToDriverEntity(model, user);

                _driverRepo.Add(driver);

                return true;
            }
        }
    }

}
