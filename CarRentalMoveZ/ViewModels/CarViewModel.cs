using System;
using System.ComponentModel.DataAnnotations;

namespace CarRentalMoveZ.ViewModels
{
    public class CarViewModel
    {
        public int CarId { get; set; }

        [Required(ErrorMessage = "Car name is required.")]
        [StringLength(100, ErrorMessage = "Car name cannot exceed 100 characters.")]
        [Display(Name = "Car Name")]
        public string CarName { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        [StringLength(50, ErrorMessage = "Brand cannot exceed 50 characters.")]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        [StringLength(50, ErrorMessage = "Model cannot exceed 50 characters.")]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Range(1900, 9999, ErrorMessage = "Please enter a valid year.")]
        [Display(Name = "Year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Price per day is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price per day must be a positive value.")]
        [Display(Name = "Price Per Day")]
        public decimal PricePerDay { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status")]
        public string Status { get; set; } // E.g., Available, Booked, Maintenance

        [Url(ErrorMessage = "Please enter a valid image URL.")]
        [Display(Name = "Image URL")]
        public string ImgURL { get; set; }

        // New Specifications

        [Required(ErrorMessage = "Transmission type is required.")]
        [Display(Name = "Transmission")]
        public string Transmission { get; set; }  // Automatic, Manual, etc.


        [Required(ErrorMessage = "Seats are required.")]
        [Range(1, 20, ErrorMessage = "Seats must be at least 1.")]
        [Display(Name = "Seats")]
        public int Seats { get; set; }


        [Required(ErrorMessage = "Fuel type is required.")]
        [Display(Name = "Fuel Type")]
        public string Fuel { get; set; }  // Gasoline, Diesel, Electric

        [Required(ErrorMessage = "Top speed is required.")]
        [Range(0, 400, ErrorMessage = "Top speed must be between 0 and 400 mph.")]
        [Display(Name = "Top Speed (mph)")]
        public int TopSpeed { get; set; }

        // Maintenance Info

        [Required(ErrorMessage = "Next oil change date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Next Oil Change")]
        public DateTime? NextOilChange { get; set; }


        [Required(ErrorMessage = "Tire replacement date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Tire Replacement")]
        public DateTime? TireReplacement { get; set; }
    }
}
