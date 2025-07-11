using HandbagManagementRepository;
using HandbagManagementRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandbagManagementService
{
    public interface IBrandService
    {
        Task<List<Brand>> GetAllAsync();
    }
}
