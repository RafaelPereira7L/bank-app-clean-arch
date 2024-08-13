using AutoMapper;
using Bank.Application.DTOs;
using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using Bank.Domain.Interfaces;

namespace Bank.Application.Services;

public class AccountService(IAccountRepository accountRepository, IMapper mapper) : IAccountService
{
    public async Task<Account> CreateAccountAsync(CreateAccountDTO accountDto)
    {
        var accountEntity = mapper.Map<Account>(accountDto);
        return await accountRepository.CreateAccountAsync(accountEntity);
    }

    public async Task<AccountWithBalanceDto?> GetAccountByIdAsync(Guid id)
    {
        var account = await accountRepository.GetAccountByIdAsync(id);

        if (account == null) throw new Exception("Account not found");
        var balance = account.GetBalance();

        return new AccountWithBalanceDto
        {
            Id = account.Id,
            AccountNumber = account.AccountNumber,
            AccountHolderName = account.AccountHolderName,
            Balance = balance,
            CreatedAt = account.CreatedAt,
            UpdatedAt = account.UpdatedAt,
            SentTransactions = account.SentTransactions,
            ReceivedTransactions = account.ReceivedTransactions
        };
    }

    public async Task<AccountWithBalanceDto?> GetAccountByAccountNumberAsync(string accountNumber)
    {
        var account = await accountRepository.GetAccountByAccountNumberAsync(accountNumber);

        if (account == null) throw new Exception("Account not found");
        var balance = account.GetBalance();

        return new AccountWithBalanceDto
        {
            Id = account.Id,
            AccountNumber = account.AccountNumber,
            AccountHolderName = account.AccountHolderName,
            Balance = balance,
            CreatedAt = account.CreatedAt,
            UpdatedAt = account.UpdatedAt,
            SentTransactions = account.SentTransactions,
            ReceivedTransactions = account.ReceivedTransactions
        };
    }

    public async Task<IEnumerable<Account>> GetAccountsAsync()
    {
        return await accountRepository.GetAccountsAsync();
    }

    public async Task UpdateAccountAsync(Guid id, UpdateAccountDTO accountDto)
    {
        var account = await accountRepository.GetAccountByIdAsync(id);

        if (account == null) throw new Exception("Account not found");
        
        account.AccountHolderName = accountDto.AccountHolderName;
        await accountRepository.UpdateAccountAsync(account);
    }

    public async Task DeleteAccountAsync(Guid id)
    {
        var account = await accountRepository.GetAccountByIdAsync(id);
        if (account is null)
        {
            throw new Exception("Account not found");
        }
        
        await accountRepository.DeleteAccountAsync(account.Id);
    }
}