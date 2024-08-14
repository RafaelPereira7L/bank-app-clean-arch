using Bank.Domain.Entities;
using Bank.Domain.Interfaces;
using Bank.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infra.Data.Repositories;

public class TransactionRepository(ApplicationDbContext context) : ITransactionRepository
{
    public async Task DepositAsync(Transaction depositTransaction)
    {
        context.Transactions.Add(depositTransaction);
        await context.SaveChangesAsync();
    }

    public async Task WithdrawAsync(Transaction withdrawTransaction)
    {
        context.Transactions.Add(withdrawTransaction);
        await context.SaveChangesAsync();
    }

    public async Task TransferAsync(Transaction transferTransaction)
    {
        context.Transactions.Add(transferTransaction);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsAsync(string accountNumber)
    {
        return await context.Transactions
            .Include(t => t.SenderAccount)
            .Include(t => t.ReceiverAccount)
            .Where(t => t.SenderAccount.AccountNumber == accountNumber || t.ReceiverAccount.AccountNumber == accountNumber)
            .ToListAsync();
    }
}