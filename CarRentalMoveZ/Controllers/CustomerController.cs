using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalMoveZ.Controllers
{
    public class CustomerController : Controller
    {
        
        public IActionResult Dashboard()
        {
            //ViewData["Layout"] = "~/Views/Shared/_CustomerLayout.cshtml";
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
            return View();
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
