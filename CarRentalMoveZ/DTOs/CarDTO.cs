using System.ComponentModel.DataAnnotations;

namespace CarRentalMoveZ.DTOs
{
    public class CarDTO
    {
        public int CarId { get; set; }

      
        public string CarName { get; set; }

      
        public string Brand { get; set; }

      
        public string Model { get; set; }
        public int Year { get; set; }

        
        public decimal PricePerDay { get; set; }

        public string Status { get; set; }   // Available, Booked, Maintenance

        public string ImgURL { get; set; }
    }
}
