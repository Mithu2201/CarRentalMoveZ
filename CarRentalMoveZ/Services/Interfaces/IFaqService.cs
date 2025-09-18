using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.ViewModels;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface IFaqService
    {
        Task<IEnumerable<FaqDTO>> GetAllAsync();
        Task<FaqDTO?> GetByIdAsync(int id);
        Task AddAsync(FaqDTO faqDto);
        Task UpdateAsync(FaqDTO faqDto);
        Task DeleteAsync(int id);

        Task<FaqViewModel?> GetFaqForEditAsync(int id);
    }
}
