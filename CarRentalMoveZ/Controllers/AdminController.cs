using CarRentalMoveZ.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentalMoveZ.Controllers
{
    public class AdminController : Controller
    {
        
        public IActionResult Dashboard()
        {
            return View();
        }

        
        public IActionResult ManageCar()
        {
            return View();
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
