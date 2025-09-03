using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;


namespace CarRentalMoveZ.Mappings
{
    public class UserProfileMapper
    {
        public static UserProfileDTO ToDTO(User user)
        {
            return new UserProfileDTO
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender
            };
        }
    }
}
