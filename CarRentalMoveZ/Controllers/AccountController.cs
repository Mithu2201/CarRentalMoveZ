using CarRentalMoveZ.Enums;
using CarRentalMoveZ.Services.Interfaces;
using CarRentalMoveZ.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRentalMoveZ.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRegisterService _registerService;
        private readonly ILoginService _loginService;

        public AccountController(IRegisterService registerService, ILoginService loginService)
        {
            _registerService = registerService;
            _loginService = loginService;
        }


        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.RoleList = new SelectList(Enum.GetValues(typeof(Gender)));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.RoleList = new SelectList(Enum.GetValues(typeof(Gender)));
                return View(model);
            }

            _registerService.Register(model);
            return RedirectToAction("Login", "Account");
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (_loginService.ValidateUser(model, out int userId, out string role, out string name))
            {
                HttpContext.Session.SetString("UserName", name);
                HttpContext.Session.SetString("Role", role); // store the role
                HttpContext.Session.SetInt32("UserId", userId);

                // Redirect all roles to the same Admin dashboard
                return RedirectToAction("Dashboard", "Admin");
            }

            ModelState.AddModelError("", "Invalid email or password");
            return View(model);
        }



        [HttpGet]
        public IActionResult ChangePassword()
        {
            if (TempData["VerifiedEmail"] == null)
                return RedirectToAction("VerifyEmail");

            ViewBag.Email = TempData["VerifiedEmail"].ToString();
            TempData.Keep("VerifiedEmail"); // keep it alive for POST
            return View(new ChangePasswordViewModel { Email = ViewBag.Email });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (_loginService.ChangePassword(model.Email, model.NewPassword))
            {
                TempData["Success"] = "Password changed successfully. Please login.";
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Unable to change password. Try again.");
            return View(model);
        }

        [HttpGet]
        public IActionResult VerifyEmail()
        {
            return View(new VerifyEmailViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VerifyEmail(VerifyEmailViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (_loginService.VerifyEmail(model.Email))
            {
                // ✅ Store email temporarily (TempData is good for this)
                TempData["VerifiedEmail"] = model.Email;
                return RedirectToAction("ChangePassword");
            }

            ModelState.AddModelError("", "Email not found");
            return View(model);
        }



    }   
}
