using System.ComponentModel.DataAnnotations;

namespace CarRentalMoveZ.Models
{
    public class Faq
    {
        [Key]
        public int FaqId { get; set; }

        [Required]
        [StringLength(200)]
        public string Question { get; set; }

        [Required]
        [StringLength(1000)]
        public string Answer { get; set; }
    }
}
