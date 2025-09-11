using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface IOfferService
    {
        void Add(OfferViewModel offer);

        IEnumerable<OfferDTO> GetAll();
    }
}
