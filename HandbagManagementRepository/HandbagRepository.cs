using HandbagManagementRepository.Basic;
using HandbagManagementRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace HandbagManagementRepository
{
    public class HandbagRepository : GenericRepository<Handbag>
    {

        private Summer2025HandbagDbContext _dbContext;
        private static HandbagRepository instance;

        public HandbagRepository()
        {
            _dbContext = new Summer2025HandbagDbContext();
        }

        public static HandbagRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HandbagRepository();
                }
                return instance;
            }
        }

        public async Task<List<Handbag>> GetAllAsync()
        {
            return await _dbContext.Handbags
                .Include(o => o.Brand)
                .ToListAsync();
        }

        public async Task<Handbag> GetByIdAsync(int id)
        {
            return await _dbContext.Handbags.Include(o => o.Brand).FirstOrDefaultAsync(o => o.HandbagId == id);
        }

        public async Task<int> GetMaxIdAsync()
        {
            return _dbContext.Handbags.Max(o => o.HandbagId);
        }
    }
}
