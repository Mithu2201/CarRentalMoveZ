using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Mappings;
using CarRentalMoveZ.Repository.Interfaces;
using CarRentalMoveZ.Services.Interfaces;

namespace CarRentalMoveZ.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public UserProfileDTO GetProfile(int userId)
        {
            var user = _repo.GetById(userId);
            return user == null ? null : UserProfileMapper.ToDTO(user);
        }

        public void UpdateProfile(UserProfileDTO dto)
        {
            var user = _repo.GetById(dto.UserId);
            if (user == null) return;

            user.Name = dto.Name;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;
            user.DateOfBirth = dto.DateOfBirth;
            user.Gender = dto.Gender;

            _repo.Update(user);
        }
    }
}
