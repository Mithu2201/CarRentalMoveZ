using System.ComponentModel.DataAnnotations;

namespace CarRentalMoveZ.ViewModels
{
    public class FaqViewModel
    {
        public int FaqId { get; set; }

        [Required]
        [StringLength(200)]
        public string Question { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Answer { get; set; } = string.Empty;
    }
}
