using HandbagManagementRepository;
using HandbagManagementRepository.Models;

namespace HandbagManagementService
{
    public class SystemAccountService : ISystemAccountService
    {
        public async Task<SystemAccount> GetAccount(string email, string password)
            => await SystemAccountRepository.Instance.GetAccountAsync(email, password);
    }
}
