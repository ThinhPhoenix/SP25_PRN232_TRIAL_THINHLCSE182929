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
    public class SystemAccountRepository : GenericRepository<SystemAccount>
    {

        private Summer2025HandbagDbContext _dbContext;
        private static SystemAccountRepository instance;

        public SystemAccountRepository()
        {
            _dbContext = new Summer2025HandbagDbContext();
        }

        public static SystemAccountRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SystemAccountRepository();
                }
                return instance;
            }
        }

        public async Task<SystemAccount> GetAccountAsync(string email, string password)
        {
            return await _dbContext.SystemAccounts.FirstOrDefaultAsync(a => a.Email.Equals(email) && a.Password.Equals(password));
        }
    }
}
