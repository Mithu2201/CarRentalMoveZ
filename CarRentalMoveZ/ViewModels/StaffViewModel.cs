using System.ComponentModel.DataAnnotations;

namespace CarRentalMoveZ.ViewModels
{
    public class StaffViewModel
    {
        public int Id { get; set; } // Staff ID

        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; } // Male | Female | Others

        [Required]
        public string Role { get; set; } // Admin or Staff

        // Email will be displayed as read-only
        public string Email { get; set; } // Email is read-only for the edit form
    }
}
