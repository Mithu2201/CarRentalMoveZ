using System;
using System.ComponentModel.DataAnnotations;

namespace CarRentalMoveZ.ViewModels
{
    public class OfferViewModel
    {
        public int OfferId { get; set; }

        [Required(ErrorMessage = "Promo Code is required")]
        [StringLength(50)]
        [Display(Name = "Promo Code")]
        public string PromoCode { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100)]
        [Display(Name = "Offer Title")]
        public string Title { get; set; }

        [StringLength(255)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Discount % is required")]
        [Range(1, 100, ErrorMessage = "Discount must be between 1% and 100%")]
        [Display(Name = "Discount (%)")]
        public int DiscountPercentage { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "Active"; // Active / Expired / Upcoming
    }
}
