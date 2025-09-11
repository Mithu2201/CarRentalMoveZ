using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalMoveZ.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }   // Navigation property

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required, StringLength(50)]
        public string LicenseNo { get; set; }

        [Required]
        public string Status { get; set; }   // Active / Inactive / Suspended

        [NotMapped]
        public string Role ="Driver";  // Fixed role
    }
}
