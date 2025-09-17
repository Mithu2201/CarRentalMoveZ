using CarRentalMoveZ.DTOs;

namespace CarRentalMoveZ.Services.Interfaces
{
    public interface IFaqService
    {
        Task<IEnumerable<FaqDTO>> GetAllAsync();
        Task<FaqDTO?> GetByIdAsync(int id);
        Task AddAsync(FaqDTO faqDto);
        Task UpdateAsync(FaqDTO faqDto);
        Task DeleteAsync(int id);
    }
}
