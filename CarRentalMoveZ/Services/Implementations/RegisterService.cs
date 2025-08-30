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
        private readonly PasswordHasher<User> _passwordHasher;


        public RegisterService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _passwordHasher = new PasswordHasher<User>();
        }

        public void Register(RegisterViewModel model)
        {
            var user = RegisterMapper.ToUserEntity(model, null);

            // Hash password with Identity PasswordHasher
            user.Password = _passwordHasher.HashPassword(user, model.Password);

            _userRepo.Add(user);

        }
    }

}
