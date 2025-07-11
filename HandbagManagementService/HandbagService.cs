using HandbagManagementRepository;
using HandbagManagementRepository.Models;

namespace HandbagManagementService
{
    public class HandbagService : IHandbagService
    {
        public async Task<List<Handbag>> GetAllAsync()
            => await HandbagRepository.Instance.GetAllAsync();
        public async Task<Handbag> GetByIdAsync(int id)
            => await HandbagRepository.Instance.GetByIdAsync(id);
        public async Task<int> CreateAsync(Handbag handbag)
            => await HandbagRepository.Instance.CreateAsync(handbag);
        public async Task<int> UpdateAsync(Handbag handbag)
            => await HandbagRepository.Instance.UpdateAsync(handbag);
        public async Task<bool> RemoveAsync(int id)
        {
            var handbag = await HandbagRepository.Instance.GetByIdAsync(id);
            return await HandbagRepository.Instance.RemoveAsync(handbag);
        }
        public async Task<int> GetMaxIdAsync()
            => await HandbagRepository.Instance.GetMaxIdAsync();
    }
}
