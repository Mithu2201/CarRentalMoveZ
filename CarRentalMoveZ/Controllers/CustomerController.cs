
using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.Services.Implementations;
using CarRentalMoveZ.Services.Interfaces;
using CarRentalMoveZ.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalMoveZ.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICarService _carService;
        private readonly IBookingService _bookingService;
        private readonly ICustomerService _customerService;

        public CustomerController(IUserService userService, ICarService carService, IBookingService bookingService,ICustomerService customerService)
        {
            _userService = userService;
            _carService = carService;
            _bookingService = bookingService;
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult NewBooking(int carId,int customerId)
        {
            var car = _carService.GetCarById(carId);

            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var customer = _customerService.GetCustomerByUserId(userId.Value);
            if (customer == null)
                return NotFound("Customer not found.");

            var vm = new BookingViewModel
            {
                CarId = car.CarId,
                CarName = car.CarName,
                ImgURL = car.ImgURL,
                PricePerDay = car.PricePerDay,

                CustomerId = customer.CustomerId,
                CustomerName = customer.Name,
                PhoneNumber =  customer.PhoneNumber
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult NewBooking(BookingViewModel model)
        {
            if (ModelState.IsValid)
            {
                _bookingService.CreateBooking(model); // Mapper handles conversion

                return RedirectToAction("Car", "Customer");
            }

            return View(model);
        }

        public IActionResult Dashboard()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult TestPost()
        {
            Console.WriteLine("🚀 TestPost HIT!");
            return Ok("POST worked");
        }

        public IActionResult Car()
        {
            return View(_carService.GetAll());
        }


        public IActionResult BookingDetails()
        {
            return View();
        }

        
        public IActionResult MyBooking()
        {
            return View();
        }

        
        public IActionResult Profile()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Dashboard", "Customer"); // force login
            }

            var profile = _userService.GetProfile(userId.Value);
            if (profile == null)
                return NotFound();

            return View(profile);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var profile = _userService.GetProfile(userId.Value);
            if (profile == null) return NotFound();

            // map profile to UserProfileDTO
            var dto = new UserProfileDTO
            {
                UserId = profile.UserId,
                Name = profile.Name,
                Email = profile.Email,
                PhoneNumber = profile.PhoneNumber,
                DateOfBirth = profile.DateOfBirth,
                Gender = profile.Gender
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProfile(UserProfileDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _userService.UpdateProfile(model);

            return RedirectToAction("Profile");
        }


        public IActionResult Payment()
        {
            return View();
        }

        
        public IActionResult PaymentDetails()
        {
            return View();
        }
    }
}
