using CarRentalMoveZ.Models;
using CarRentalMoveZ.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarRentalMoveZ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;
        public HomeController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Service()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult BrowseCar()
        {
            return View(_carService.GetAllAvailable());
        }

        public IActionResult CarDetail(int id)
        {
            var car = _carService.GetCarById(id);
            return View(car);
        }


        public IActionResult Logout()
        {
            // Clear session
            HttpContext.Session.Clear();

            // If using authentication cookies, also sign out
            HttpContext.SignOutAsync();

            // Redirect to login or home page
            return RedirectToAction("Index", "Home");
        }

    }
}
