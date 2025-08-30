using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface ILoginService
    {
        bool ValidateUser(LoginViewModel model, out int userId, out bool isAdmin, out string name);
        bool VerifyEmail(string email);   // ✅ Check if email exists
        bool ChangePassword(string email, string newPassword);  // ✅ Update password
    }
}
