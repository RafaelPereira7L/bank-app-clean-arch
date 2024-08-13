using Bank.Domain.Entities;

namespace Bank.Domain.Interfaces;

public interface IAccountRepository
{
    Task<Account> CreateAccountAsync(Account account);
    Task<Account?> GetAccountByIdAsync(Guid id);
    Task<Account?> GetAccountByAccountNumberAsync(string accountNumber);
    Task<IEnumerable<Account>> GetAccountsAsync();
    Task<Account> UpdateAccountAsync(Account account);
    Task DeleteAccountAsync(Guid id);
}