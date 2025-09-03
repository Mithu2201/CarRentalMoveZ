using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalMoveZ.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUserService _userService;

        public CustomerController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Dashboard()
        {
            
            return View();
        }


        public IActionResult BookingDetails()
        {
            return View();
        }

        
        public IActionResult MyBooking()
        {
            return View();
        }

        
        public IActionResult NewBooking()
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
