namespace CarRentalMoveZ.DTOs
{
    public class OfferDTO
    {
        public int OfferId { get; set; }
        public string PromoCode { get; set; }
        public string Title { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } // Active / Expired / Upcoming
        public string Description { get; internal set; }
    }
}
