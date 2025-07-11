using HandbagManagementRepository.Models;

namespace HandbagManagementService
{
    public interface ISystemAccountService
    {
        Task<SystemAccount> GetAccount(string email, string password);
    }
}
