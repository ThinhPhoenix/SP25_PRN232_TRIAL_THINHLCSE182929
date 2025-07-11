using HandbagManagementRepository;
using HandbagManagementRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandbagManagementService
{
    public class BrandService : IBrandService
    {
        public async Task<List<Brand>> GetAllAsync()
            => await BrandRepository.Instance.GetAllAsync();
    }
}
