using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Mappings;
using CarRentalMoveZ.Repository.Interfaces;
using CarRentalMoveZ.Services.Interfaces;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Implementations
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository offerRepository;

        public OfferService(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        public void Add(OfferViewModel offer)
        {
            var Offer = OfferMapper.ToEntity(offer);

            offerRepository.Add(Offer);
        }

        public IEnumerable<OfferDTO> GetAll()
        {
            var offers = offerRepository.GetAllOffers();
            return OfferMapper.ToDTOList(offers);

        }

        public async Task<List<OfferDTO>> GetActiveOffersAsync()
        {
            var entities = await offerRepository.GetActiveOffersAsync();
            return entities.Select(o => o.ToDTO()).ToList();
        }

        public void Update(OfferViewModel offer)
        {
            var Offer = OfferMapper.ToEntity(offer);
            offerRepository.Update(Offer);
        }

        public OfferViewModel GetById(int id)
        {
            var offer = offerRepository.GetById(id);
            if (offer == null) return null;

            return new OfferViewModel
            {
                OfferId = offer.OfferId,
                PromoCode = offer.PromoCode,
                Title = offer.Title,
                Description = offer.Description,
                DiscountPercentage = offer.DiscountPercentage,
                StartDate = offer.StartDate,
                EndDate = offer.EndDate,
                Status = offer.Status
            };
        }

        public void Delete(int id)
        {
            var offer = offerRepository.GetById(id);
            if (offer != null)
            {
                offerRepository.Delete(offer);
            }
        }
    }
}

