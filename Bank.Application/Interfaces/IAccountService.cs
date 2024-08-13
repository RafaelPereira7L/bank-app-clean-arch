using Bank.Application.DTOs;
using Bank.Domain.Entities;

namespace Bank.Application.Interfaces;

public interface IAccountService
{
    Task<Account> CreateAccountAsync(CreateAccountDTO account);
    Task<AccountWithBalanceDto?> GetAccountByIdAsync(Guid id);
    Task<AccountWithBalanceDto?> GetAccountByAccountNumberAsync(string accountNumber);
    Task<IEnumerable<Account>> GetAccountsAsync();
    Task UpdateAccountAsync(Guid id, UpdateAccountDTO account);
    Task DeleteAccountAsync(Guid id);
}