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
        private readonly PasswordHasher<User> _passwordHasher;

        public LoginService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _passwordHasher = new PasswordHasher<User>();
        }

        public bool ValidateUser(LoginViewModel model, out int userId, out bool isAdmin, out string name)
        {
            userId = 0;
            isAdmin = false;
            name = string.Empty;
          

            // 🔹 Hardcoded admin credentials
            if (model.Email == "" +
                "admin@movez.com" && model.Password == "Admin@123")
            {
                isAdmin = true;
                userId = -1; // fake Id for admin
                name = "Admin";
             
                return true;
            }


            // get user by email
            var user = _userRepo.GetByEmail(model.Email);
            if (user == null) return false;

            // verify password
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);
            if (result == PasswordVerificationResult.Success && user.Role == "Admin")
            {
                userId = user.UserId;
                name = user.Name;
                isAdmin = true;
          
                return true;
            }
            else if (result == PasswordVerificationResult.Success && user.Role == "Customer")
            {
                userId = user.UserId;
                name = user.Name;
                isAdmin = false;
            
                return true;
            }
            else if (result == PasswordVerificationResult.Success && user.Role == "Staff")
            {
                userId = user.UserId;
                name = user.Name;
                isAdmin = true;
              
                return true;
            }
            else if (result == PasswordVerificationResult.Success && user.Role == "Driver")
            {
                userId = user.UserId;
                name = user.Name;
                isAdmin = true;
              
                return true;
            }

            return false;



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
    }
}
