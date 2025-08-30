using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalMoveZ.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public string Department { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

