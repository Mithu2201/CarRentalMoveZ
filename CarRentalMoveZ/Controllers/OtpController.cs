using CarRentalMoveZ.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalMoveZ.Controllers
{
    public class OtpController : Controller
    {
        private readonly EmailService _emailService;

        // Use dependency injection
        public OtpController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendOtp(string email)
        {
            var otp = new Random().Next(100000, 999999).ToString();

            // Store OTP in session
            HttpContext.Session.SetString("CurrentOTP", otp);

            await _emailService.SendEmailAsync(email, "Your OTP Code", $"Your OTP is: <b>{otp}</b>");

            return Json(new { success = true, message = "OTP sent successfully!" });
        }

        [HttpPost]
        public IActionResult VerifyOtp(string enteredOtp)
        {
            var storedOtp = HttpContext.Session.GetString("CurrentOTP");

            if (storedOtp == enteredOtp)
            {
                return Json(new { success = true, message = "OTP verified!" });
            }

            return Json(new { success = false, message = "Invalid OTP!" });
        }
    }
}
