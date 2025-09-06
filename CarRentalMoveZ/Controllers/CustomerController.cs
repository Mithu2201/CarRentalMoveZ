
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
        private readonly IPaymentService _paymentService;

        public CustomerController(IUserService userService, ICarService carService, IBookingService bookingService,ICustomerService customerService, IPaymentService paymentService)
        {
            _userService = userService;
            _carService = carService;
            _bookingService = bookingService;
            _customerService = customerService;
            _paymentService = paymentService;
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
                var bid=_bookingService.CreateBooking(model); // Mapper handles conversion
               
                TempData["BookingId"]= bid;
                TempData.Keep("BookingId"); // keep it alive for next request
                TempData["Amount"] = model.Amount.ToString(System.Globalization.CultureInfo.InvariantCulture);

                return RedirectToAction("Payment", "Customer");
            }

            return View(model);
        }

        public IActionResult Dashboard()
        {
            
            return View();
        }

        public IActionResult Car()
        {
            return View(_carService.GetAllAvailable());
        }

        [HttpGet]
        public IActionResult BookingDetails()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var bookings = _bookingService.GetBookingsByUserId(userId.Value);
            return View(bookings);
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

        [HttpGet]
        public IActionResult Payment()
        {
            if (TempData["BookingId"] == null || TempData["Amount"] == null)
            {
                // Optional: handle missing TempData (e.g., redirect to error or booking page)
                return RedirectToAction("NewBooking", "Customer");
            }

            // Convert TempData values safely
            int bookingId = Convert.ToInt32(TempData["BookingId"]);
            decimal amount = Convert.ToDecimal(TempData["Amount"]);

            // Keep TempData alive for the next request (e.g., POST)
            TempData.Keep("BookingId");
            TempData.Keep("Amount");

            // Pass to ViewModel
            var model = new PaymentViewModel
            {
                BookingId = bookingId,
                Amount = amount
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Payment(PaymentViewModel model)
        {
            if (TempData["BookingId"] == null || TempData["Amount"] == null)
            {
                return RedirectToAction("NewBooking", "Customer");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.BookingID = TempData["BookingId"].ToString();
                TempData.Keep("BookingId");
                TempData.Keep("Amount");
                return View(model);
            }
            // Process payment (mock)
            // In real scenario, integrate with payment gateway here
            // Update booking status to Confirmed
            _paymentService.addPayment(model);
            return RedirectToAction("Car");
        }

        [HttpGet]
        public IActionResult PaymentDetails()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var payments = _paymentService.GetPaymentsByUserId(userId.Value);
            return View(payments);
        }
    }
}
