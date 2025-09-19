using CarRentalMoveZ.Data;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.Services.Interfaces;
using CarRentalMoveZ.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CarRentalMoveZ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;
        private readonly IFaqService _faqService;
        public HomeController(ICarService carService,IFaqService faqService)
        {
            _carService = carService;
            _faqService = faqService;

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


        public async Task<IActionResult> Faq()
        {
            var faqs = await _faqService.GetAllAsync(); // Await the result
            return View(faqs);
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

        [HttpGet]
        public IActionResult Comparison()
        {
            var model = new CarComparisonViewModel
            {
                AvailableCars = _carService.GetAll().ToList()
            };
            return View(model);
        }

    }
}
