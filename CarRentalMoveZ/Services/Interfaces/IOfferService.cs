using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface IOfferService
    {
        void Add(OfferViewModel offer);

        IEnumerable<OfferDTO> GetAll();

        Task<List<OfferDTO>> GetActiveOffersAsync();

        OfferViewModel GetById(int id);

        void Update(OfferViewModel offer);

        void Delete(int id);
    }
}
