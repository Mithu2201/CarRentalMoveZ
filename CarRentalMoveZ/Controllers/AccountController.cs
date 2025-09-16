using CarRentalMoveZ.Enums;
using CarRentalMoveZ.Services.Interfaces;
using CarRentalMoveZ.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

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
                if (role =="Admin" || role=="Staff" || role == "Driver")
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                else if (role == "Customer")
                {
                    return RedirectToAction("Dashboard", "Customer");
                }
                else
                {
                    // Unknown role, logout for safety
                    return RedirectToAction("Logout", "Account");
                }
               
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

        // -------------------- Trigger Google Login --------------------
        [HttpGet]
        public IActionResult GoogleLogin(string returnUrl = "/")
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse", new { returnUrl })
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        // -------------------- Handle Google Callback --------------------
        [HttpGet]
        public async Task<IActionResult> GoogleResponse(string returnUrl = "/")
        {
            // Get user info from Google
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded)
                return RedirectToAction("Login");

            var claims = result.Principal.Identities.FirstOrDefault()?.Claims;
            var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Login");

            // Check if user exists
            var user = _loginService.GetUserByEmail(email);
            if (user == null)
            {
                // Create new user for Google login
                user = _loginService.CreateGoogleUser(email, name);
            }

            // Set session
            HttpContext.Session.SetInt32("UserId", user.UserId);
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("Role", user.Role);

            // Redirect by role
            return user.Role switch
            {
                "Admin" or "Staff" or "Driver" => RedirectToAction("Dashboard", "Admin"),
                "Customer" => RedirectToAction("Dashboard", "Customer"),
                _ => RedirectToAction("Logout", "Account"),
            };
        }

    }   
}
