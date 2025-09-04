using CarRentalMoveZ.Enums;
using CarRentalMoveZ.Services.Implementations;
using CarRentalMoveZ.Services.Interfaces;
using CarRentalMoveZ.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentalMoveZ.Controllers
{
    public class AdminController : Controller
    {

        private readonly ICarService _carService;
        private readonly IStaffService _staffService;
        private readonly IRegisterService _registerService;
        private readonly ICustomerService _customerService;

        public AdminController(ICarService carService, IStaffService staffService, IRegisterService registerService, ICustomerService customerService)
        {
            _carService = carService;
            _staffService = staffService;
            _registerService = registerService;
            _customerService = customerService;
        }

        public IActionResult Dashboard()
        {
            return View();
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


        public IActionResult CarDetails()
        {
            return View();
        }

        
        public IActionResult ManageBookings()
        {
            return View();
        }

        
        public IActionResult BookingDetails()
        {
            return View();
        }

        
        public IActionResult ManagePayment()
        {
            return View();
        }

        
        public IActionResult PaymentDetails()
        {
            return View();
        }

        
        public IActionResult ManageCustomer() => View(_customerService.GetAllCustomer());



        public IActionResult CustomerDetails()
        {
            return View();
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
                return RedirectToAction("Login", "Account"); // Optionally redirect to another action
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


        public IActionResult StaffDetails()
        {
            return View();
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
