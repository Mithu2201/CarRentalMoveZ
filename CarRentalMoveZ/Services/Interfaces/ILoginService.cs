using CarRentalMoveZ.Models;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface ILoginService
    {
        public bool ValidateUser(LoginViewModel model, out int userId, out string role, out string name);
        bool VerifyEmail(string email);   // ✅ Check if email exists
        bool ChangePassword(string email, string newPassword);  // ✅ Update password


        // For Google login
        bool UserExists(string email);
        User GetUserByEmail(string email);
        User CreateGoogleUser(string email, string name, string role = "Customer");
    }
}
