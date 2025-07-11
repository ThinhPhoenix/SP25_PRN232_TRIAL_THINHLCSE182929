using HandbagManagementRepository.Basic;
using HandbagManagementRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandbagManagementRepository
{
    public class BrandRepository : GenericRepository<Brand>
    {

        private Summer2025HandbagDbContext _dbContext;
        private static BrandRepository instance;

        public BrandRepository()
        {
            _dbContext = new Summer2025HandbagDbContext();
        }

        public static BrandRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BrandRepository();
                }
                return instance;
            }
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            return _dbContext.Brands
                .Include(o => o.Handbags)
                .ToList();
        }
    }
}
