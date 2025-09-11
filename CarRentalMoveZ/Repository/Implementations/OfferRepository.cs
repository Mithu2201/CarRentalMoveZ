using CarRentalMoveZ.Data;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.Repository.Interfaces;

namespace CarRentalMoveZ.Repository.Implementations
{
    public class OfferRepository : IOfferRepository
    {
       private readonly AppDbContext _context;

       public OfferRepository(AppDbContext context)
       {
            _context = context;
       }

        // Implement CRUD operations for Offer entity here

        public void Add(Models.Offer offer)
        {
            _context.Offers.Add(offer);
            _context.SaveChanges();
        }


        public IEnumerable<Offer> GetAllOffers()
        {
            return _context.Offers.ToList();
        }
    }
}
