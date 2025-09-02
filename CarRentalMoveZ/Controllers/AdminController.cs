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

        public AdminController(ICarService carService)
        {
            _carService = carService;
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

        
        public IActionResult ManageCustomer()
        {
            return View();
        }

        
        public IActionResult CustomerDetails()
        {
            return View();
        }

        
        public IActionResult ManageStaff()
        {
            return View();
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
