using System.ComponentModel.DataAnnotations;

namespace CarRentalMoveZ.Models
{
    public class Car
    {
        public int CarId { get; set; }

        [Required]
        public string CarName { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }
        public int Year { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }

        public string Status { get; set; }   // Available, Booked, Maintenance

        public string ImgURL { get; set; }


        // New Specifications
        public string Transmission { get; set; }   // Automatic, Manual, etc.
        public int Seats { get; set; }             // Number of seats
        public string Fuel { get; set; }           // Gasoline, Diesel, Electric
        public int TopSpeed { get; set; }          // mph or km/h

        // Maintenance Info
        public DateTime? NextOilChange { get; set; }
        public DateTime? TireReplacement { get; set; }

    }
}
