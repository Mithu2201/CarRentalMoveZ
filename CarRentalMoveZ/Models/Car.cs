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
    }
}
