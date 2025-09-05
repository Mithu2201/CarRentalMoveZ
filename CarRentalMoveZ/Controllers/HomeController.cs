using CarRentalMoveZ.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarRentalMoveZ.Controllers
{
    public class HomeController : Controller
    {

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
            return View();
        }
    }
}
