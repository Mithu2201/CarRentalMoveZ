using CarRentalMoveZ.DTOs;

namespace CarRentalMoveZ.ViewModels
{
    public class CarComparisonViewModel
    {
        public List<CarDTO> AvailableCars { get; set; } = new List<CarDTO>();

        public CarViewModel? Car1 { get; set; }
        public CarViewModel? Car2 { get; set; }

        public int? Car1Id { get; set; }
        public int? Car2Id { get; set; }
    }
}
