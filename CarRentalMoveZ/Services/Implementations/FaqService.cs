using CarRentalMoveZ.DTOs;
using CarRentalMoveZ.Models;
using CarRentalMoveZ.Repository.Interfaces;
using CarRentalMoveZ.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalMoveZ.Services.Implementations
{
    public class FaqService : IFaqService
    {
        private readonly IFaqRepository _faqRepository;

        public FaqService(IFaqRepository faqRepository)
        {
            _faqRepository = faqRepository;
        }

        public async Task<IEnumerable<FaqDTO>> GetAllAsync()
        {
            var faqs = await _faqRepository.GetAllAsync();
            return faqs.Select(f => new FaqDTO
            {
                FaqId = f.FaqId,
                Question = f.Question,
                Answer = f.Answer
            });
        }

        public async Task<FaqDTO?> GetByIdAsync(int id)
        {
            var faq = await _faqRepository.GetByIdAsync(id);
            if (faq == null) return null;

            return new FaqDTO
            {
                FaqId = faq.FaqId,
                Question = faq.Question,
                Answer = faq.Answer
            };
        }

        public async Task AddAsync(FaqDTO faqDto)
        {
            var faq = new Faq
            {
                Question = faqDto.Question,
                Answer = faqDto.Answer
            };
            await _faqRepository.AddAsync(faq);
        }

        public async Task UpdateAsync(FaqDTO faqDto)
        {
            var faq = await _faqRepository.GetByIdAsync(faqDto.FaqId);
            if (faq != null)
            {
                faq.Question = faqDto.Question;
                faq.Answer = faqDto.Answer;
                await _faqRepository.UpdateAsync(faq);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _faqRepository.DeleteAsync(id);
        }
    }
}
