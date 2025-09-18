using System.ComponentModel.DataAnnotations;

namespace CarRentalMoveZ.ViewModels
{
    public class DriverViewModel
    {
        public int DriverId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "License Number")]
        public string LicenseNo { get; set; }


        public string Role { get; set; } = "Driver";  // Fixed role
    }
}
