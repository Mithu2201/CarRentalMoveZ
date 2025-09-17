using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Mappings
{
    public static class OfferMapper
    {
        public static Offer ToEntity(this OfferViewModel vm)
        {
            if (vm == null) return null;

            return new Offer
            {
                OfferId = vm.OfferId,
                PromoCode = vm.PromoCode,
                Title = vm.Title,
                Description = vm.Description,
                DiscountPercentage = vm.DiscountPercentage,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                Status = CalculateStatus(vm.StartDate, vm.EndDate)
            };
        }

        // Helper to calculate status
        private static string CalculateStatus(DateTime start, DateTime end)
        {
            var now = DateTime.Now;
            if (now < start) return "Upcoming";
            if (now > end) return "Expired";
            return "Active";
        }

        public static IEnumerable<OfferDTO> ToDTOList(IEnumerable<Offer> offers)
        {
            if (offers == null)
                return null;

            return offers
                .Where(o => o != null)
                .Select(o => new OfferDTO
                {
                    OfferId = o.OfferId,
                    PromoCode = o.PromoCode,
                    Title = o.Title,
                    Description = o.Description,
                    DiscountPercentage = o.DiscountPercentage,
                    StartDate = o.StartDate,
                    EndDate = o.EndDate,
                    Status = CalculateStatus(o.StartDate, o.EndDate) // same helper from mapper
                });
        }

        public static OfferDTO ToDTO(this Offer entity)
        {
            return new OfferDTO
            {
                OfferId = entity.OfferId,
                PromoCode = entity.PromoCode,
                Title = entity.Title,
                Description = entity.Description,
                DiscountPercentage = entity.DiscountPercentage,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Status = entity.Status
            };
        }
    }
}
