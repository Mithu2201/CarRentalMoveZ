using System.ComponentModel.DataAnnotations;


namespace CarRentalMoveZ.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Role { get; set; } = "Customer"; 
    }
}
