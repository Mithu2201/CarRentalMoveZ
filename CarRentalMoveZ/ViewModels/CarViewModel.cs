using System.ComponentModel.DataAnnotations;

namespace CarRentalMoveZ.ViewModels
{
    public class CarViewModel
    {
        public int CarId { get; set; }

        [Required]
        [Display(Name = "Car Name")]
        public string CarName { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Range(1900, 9999, ErrorMessage = "Please enter a valid year.")]
        [Display(Name = "Year")]
        public int Year { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price per day must be a positive value.")]
        [Display(Name = "Price Per Day")]
        public decimal PricePerDay { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; } // E.g., Available, Booked, Maintenance

        [Url]
        [Display(Name = "Image URL")]
        public string ImgURL { get; set; }
    }
}
