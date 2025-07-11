using HandbagManagementRepository;
using HandbagManagementRepository.Models;

namespace HandbagManagementService
{
    public interface IHandbagService
    {
        Task<List<Handbag>> GetAllAsync();
        Task<Handbag> GetByIdAsync(int id);
        Task<int> CreateAsync(Handbag handbag);
        Task<int> UpdateAsync(Handbag handbag);
        Task<bool> RemoveAsync(int id);
        Task <int> GetMaxIdAsync();
    }
}
