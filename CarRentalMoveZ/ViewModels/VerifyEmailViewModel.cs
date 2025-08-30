using System.ComponentModel.DataAnnotations;

namespace CarRentalMoveZ.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        
    }
}
