using CarRentalMoveZ.DTOs;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface IUserService
    {
        UserProfileDTO GetProfile(int userId);
        void UpdateProfile(UserProfileDTO model);
    }
}
