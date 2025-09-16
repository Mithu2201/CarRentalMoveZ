using CarRentalMoveZ.Models;

namespace CarRentalMoveZ.Repository.Interfaces
{
    public interface IOfferRepository
    {
        void Add(Models.Offer offer);

        IEnumerable<Offer> GetAllOffers();

        Task<List<Offer>> GetActiveOffersAsync();
    }
}
