using CarRentalMoveZ.Models;
using CarRentalMoveZ.Repository.Interfaces;
using CarRentalMoveZ.Services.Interfaces;
using CarRentalMoveZ.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CarRentalMoveZ.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly PasswordHasher<User> _passwordHasher;

        public LoginService(IUserRepository userRepo, ICustomerRepository customerRepo)
        {
            _userRepo = userRepo;
            _passwordHasher = new PasswordHasher<User>();
            _customerRepo = customerRepo;
        }
        public bool ValidateUser(LoginViewModel model, out int userId, out string role, out string name)
        {
            userId = 0;
            role = string.Empty;
            name = string.Empty;

            // Hardcoded admin credentials
            if (model.Email == "admin@movez.com" && model.Password == "Admin@123")
            {
                userId = -1; // fake Id for admin
                name = "Admin";
                role = "Admin";
                return true;
            }

            // get user by email
            var user = _userRepo.GetByEmail(model.Email);
            if (user == null) return false;

            // verify password
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);
            if (result != PasswordVerificationResult.Success) return false;

            userId = user.UserId;
            name = user.Name;
            role = user.Role; // "Admin", "Customer", "Staff", "Driver"

            return true;
        }


        public bool VerifyEmail(string email)
        {
            var user = _userRepo.GetByEmail(email);
            return user != null;
        }

        public bool ChangePassword(string email, string newPassword)
        {
            var user = _userRepo.GetByEmail(email);
            if (user == null)
                return false;

            // 🔹 Hash the new password before saving
            user.Password = _passwordHasher.HashPassword(user, newPassword);

            _userRepo.Update(user);  // assuming your repository has Update()
            return true;
        }

        // ===================== GOOGLE LOGIN METHODS =====================
        public bool UserExists(string email)
        {
            return _userRepo.GetByEmail(email) != null;
        }

        public User GetUserByEmail(string email)
        {
            return _userRepo.GetByEmail(email);
        }

        public User CreateGoogleUser(string email, string name, string role = "Customer")
        {
            var user = new User
            {
                Name = name,
                Email = email,
                Role = role,
                PhoneNumber = "Not Provided",       // required field
                Gender = "Not Specified",           // required field
                Password = _passwordHasher.HashPassword(null, Guid.NewGuid().ToString()), // random password
                DateOfBirth = null                  // optional
            };

            _userRepo.Add(user); // save user first to get UserId

            // If the user is a Customer, create a corresponding Customer entry
            if (role == "Customer")
            {
                var customer = new Customer
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Gender = user.Gender,
                    DateOfBirth = user.DateOfBirth
                };

                _customerRepo.Add(customer);
            }

            return user;
        }


    }
}
