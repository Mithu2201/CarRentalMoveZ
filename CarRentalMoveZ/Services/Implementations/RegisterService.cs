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
        private readonly PasswordHasher<User> _passwordHasher;


        public RegisterService(IUserRepository userRepo,ICustomerRepository customerRepo)
        {
            _userRepo = userRepo;
            _customerRepo = customerRepo;
            _passwordHasher = new PasswordHasher<User>();
        }

        public void Register(RegisterViewModel model)
        {
            var user = RegisterMapper.ToUserEntity(model, null);
            var customer = RegisterMapper.ToCustomerEntity(model, null);

            // Hash password with Identity PasswordHasher
            user.Password = _passwordHasher.HashPassword(user, model.Password);
            customer.Password = _passwordHasher.HashPassword(user, model.Password);

            _userRepo.Add(user);
            _customerRepo.Add(customer);

        }
    }

}
