using CarRentalMoveZ.Data;
using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Enums;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.Services.Implementations;
using CarRentalMoveZ.Services.Interfaces;
using CarRentalMoveZ.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRentalMoveZ.Controllers
{
    public class AdminController : Controller
    {

        private readonly ICarService _carService;
        private readonly IStaffService _staffService;
        private readonly IRegisterService _registerService;
        private readonly ICustomerService _customerService;
        private readonly IBookingService _bookingService;
        private readonly IPaymentService _paymentService;
        private readonly IUserService _userService;
        private readonly IDriverService _driverService;
        private readonly IOfferService _offerService;
        private readonly IDashboardService _dashboardService;

        public AdminController(ICarService carService, IStaffService staffService, IRegisterService registerService, ICustomerService customerService, IBookingService bookingService, IPaymentService paymentService, IUserService userService, IDriverService driverService, IOfferService offerService,IDashboardService dashboardService)
        {
            _carService = carService;
            _staffService = staffService;
            _registerService = registerService;
            _customerService = customerService;
            _bookingService = bookingService;
            _paymentService = paymentService;
            _userService = userService;
            _driverService = driverService;
            _offerService = offerService;
            _dashboardService = dashboardService;

        }

        public async Task<IActionResult> Dashboard()
        {
            var dashboardDto = await _dashboardService.GetDashboardDataAsync(); // <- await the Task
            return View(dashboardDto);
        }



        public IActionResult ManageCar() => View(_carService.GetAll());

        [HttpGet]
        public IActionResult AddCar()
        {
            ViewBag.CarStatusList = new SelectList(Enum.GetValues(typeof(CarStatus)).Cast<CarStatus>());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCar(CarViewModel carViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CarStatusList = new SelectList(Enum.GetValues(typeof(CarStatus)).Cast<CarStatus>());
                return View(carViewModel);
            }
            _carService.AddCar(carViewModel);

            return RedirectToAction("ManageCar");
        }

        [HttpGet]
        public IActionResult EditCar(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewBag.CarStatusList = new SelectList(Enum.GetValues(typeof(CarStatus)).Cast<CarStatus>());
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCar(CarViewModel carViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CarStatusList = new SelectList(Enum.GetValues(typeof(CarStatus)).Cast<CarStatus>());
                return View(carViewModel);
            }
            _carService.UpdateCar(carViewModel);
            return RedirectToAction("ManageCar");
        }


        [HttpPost]
        public IActionResult DeleteCar(int id)
        {
            _carService.DeleteCar(id);
            return RedirectToAction("ManageCar");
        }


        public IActionResult CarDetails(int id)
        {
            var car = _carService.GetCarById(id);
            return View(car);
        }

        
        public IActionResult ManageBookings() => View(_bookingService.GetAllBookings());


        [HttpGet]
        public IActionResult BookingDetails(int id)
        {
            var booking = _bookingService.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }

            booking.AvailableDrivers = _driverService.GetAvailableDrivers();
            return View(booking);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookingDetails(BookingDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AvailableDrivers = _driverService.GetAvailableDrivers();
                return View(model);
            }

            // Update ViewModel properties
          
            
            model.BookingStatus = "Assigned"; // update status in ViewModel
            

            // Update booking in database
            _bookingService.UpdateBooking(model);

            // Set driver OnDuty if assigned
            if (model.DriverId.HasValue)
            {
                _driverService.SetDriverOnDuty(model.DriverId.Value);
            }

            return RedirectToAction("ManageBookings");
        }



        public IActionResult ManagePayment() => View(_paymentService.GetAllPayments());



        public IActionResult PaymentDetails()
        {
            return View();
        }

        
        public IActionResult ManageCustomer() => View(_customerService.GetAllCustomer());


        public IActionResult CustomerDetails(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null) return NotFound();

            int userId = _customerService.GetCustomerUserId(id);
            var profile = _userService.GetProfile(userId);
            var bookings = _bookingService.GetBookingsByUserId(userId);
            var payments = _paymentService.GetPaymentsByUserId(userId);

            var dashboardDto = new CustomerDashboardDTO
            {
                Profile = profile,
                Bookings = bookings,
                Payments = payments
            };

            var fullViewDto = new CustomerFullViewDTO
            {
                Customer = customer,
                Dashboard = dashboardDto
            };

            return View(fullViewDto);
        }


        public IActionResult ManageStaff() => View(_staffService.GetAllStaff());

        // Refactored method to populate ViewBag with Gender and Role lists
        private void PopulateGenderRoleLists()
        {
            ViewBag.GenderList = new SelectList(Enum.GetValues(typeof(Gender)).Cast<Gender>());
            ViewBag.RoleList = new SelectList(Enum.GetValues(typeof(Role)).Cast<Role>());
        }

        [HttpGet]
        public IActionResult AddStaff()
        {
            // Populate dropdown lists
            PopulateGenderRoleLists();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStaff(RegisterStaffViewModel model)
        {
            // Populate dropdown lists again after form submission
            PopulateGenderRoleLists();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isSuccess = _registerService.RegisterStaff(model);
            if (isSuccess)
            {
                TempData["SuccessMessage"] = "Staff user created successfully.";
                return RedirectToAction("ManageStaff", "Admin"); // Optionally redirect to another action
            }
            else
            {
                TempData["ErrorMessage"] = "Email already exists. Please try again.";
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult EditStaff(int id)
        {
            var staff = _staffService.GetById(id);
            PopulateGenderRoleLists();
            return View(staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditStaff(StaffViewModel model)
        {
            if (!ModelState.IsValid)
            {
                PopulateGenderRoleLists();
                return View(model);
            }
            _staffService.Update(model);
            return RedirectToAction("ManageStaff");

        }


        public IActionResult StaffDetails(int id)
        {
            var staff = _staffService.GetById(id);
            StaffDTO staffDTO = new StaffDTO
            {
                StaffId = staff.Id,
                Name = staff.Name,
                Email = staff.Email,
                Role = staff.Role.ToString(),
                PhoneNumber = staff.PhoneNumber
            };

            return View(staffDTO);
        }


        public IActionResult DeleteStaff(int id)
        {
            //_staffService.Delete(id);
            return RedirectToAction("ManageStaff");
        }


       

        public IActionResult ManageDriver() => View(_driverService.GetAllDriver());

        public IActionResult DriverDetails(int id)
        {
            var driver = _driverService.Getbyid(id);
            return View(driver);
        }

        [HttpGet]
        public IActionResult AddDriver()
        {
            ViewBag.GenderList = new SelectList(Enum.GetValues(typeof(Gender)).Cast<Gender>());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDriver(RegisterDriverViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.GenderList = new SelectList(Enum.GetValues(typeof(Gender)).Cast<Gender>());
            }
            bool isSuccess = _registerService.RegisterDriver(model);
            if (isSuccess)
            {
                TempData["SuccessMessage"] = "Driver user created successfully.";
                return RedirectToAction("ManageDriver", "Admin"); // Optionally redirect to another action
            }
            else
            {
                TempData["ErrorMessage"] = "Email already exists. Please try again.";
                ViewBag.GenderList = new SelectList(Enum.GetValues(typeof(Gender)).Cast<Gender>());
                return View(model);
            }
        }

        public IActionResult ManageOffer() => View(_offerService.GetAll());


        [HttpGet]
        public IActionResult AddOffer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOffer(OfferViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _offerService.Add(model);
            return RedirectToAction("ManageOffer");
        }

        public IActionResult Cashier()
        {
           return View(_bookingService.GetAllBookingsDetail());
        }

        [HttpGet]
        public IActionResult CashierBookingDetails(int id)
        {
            var booking = _bookingService.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CashierBookingDetails(BookingDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Don't override PaymentStatus or IsPaid here.
            // The values come from the form:
            //   PaymentStatus = "Confirmed" OR "Refunded"
            //   IsPaid = true/false

            _paymentService.UpdatePayment(model);

            return RedirectToAction("Cashier");
        }

        public IActionResult Report()
        {
            return View();
        }

        public IActionResult CreateStaffUser()
        {
            ViewBag.GenderList = new SelectList(Enum.GetValues(typeof(Gender)));
            ViewBag.RoleList = new SelectList(Enum.GetValues(typeof(Role)));
            return View();
        }
    }
}
