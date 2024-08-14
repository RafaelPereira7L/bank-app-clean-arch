using Bank.Domain.Entities;
using Bank.Domain.Interfaces;
using Bank.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infra.Data.Repositories;

public class AccountRepository(ApplicationDbContext context) : IAccountRepository
{
    public async Task<Account> CreateAccountAsync(Account accountDto)
    {
        var account = context.Add(accountDto);
        await context.SaveChangesAsync();
        return account.Entity;
    }

    public async Task<Account?> GetAccountByIdAsync(Guid id)
    {
        return await context.Accounts
            .Include(a => a.SentTransactions)
            .Include(a => a.ReceivedTransactions)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Account?> GetAccountByAccountNumberAsync(string accountNumber)
    {
        return await context.Accounts
            .Include(a => a.SentTransactions)
            .Include(a => a.ReceivedTransactions)
            .FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
    }

    public async Task<IEnumerable<Account>> GetAccountsAsync()
    {
        return await context.Accounts
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Account> UpdateAccountAsync(Account account)
    {
        context.Accounts.Update(account);
        await context.SaveChangesAsync();
        return account;
    }

    public async Task DeleteAccountAsync(Account account)
    {
        context.Accounts.Remove(account);
        await context.SaveChangesAsync();
    }
}