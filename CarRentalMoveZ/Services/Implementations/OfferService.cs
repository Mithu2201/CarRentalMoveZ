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
    }
}

