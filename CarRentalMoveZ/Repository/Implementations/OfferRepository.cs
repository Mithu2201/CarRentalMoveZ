using CarRentalMoveZ.Data;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Offer>> GetActiveOffersAsync()
        {
            return await _context.Offers
                .Where(o => o.Status == "Active" && o.StartDate <= DateTime.Now && o.EndDate >= DateTime.Now)
                .ToListAsync();
        }
    }
}
