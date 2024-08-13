using Bank.Domain.Entities;
using Bank.Domain.Interfaces;
using Bank.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infra.Data.Repositories;

public class TransactionRepository(ApplicationDbContext context) : ITransactionRepository
{
    public async Task<Transaction> DepositAsync(string receiverAccountNumber, decimal amount)
    {
        var receiverAccount = await context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == receiverAccountNumber);
        
        if (receiverAccount == null)
        {
            throw new Exception("Account not found");
        }
        
        var transaction = Transaction.Factories.Deposit(receiverAccount, amount);
        
        context.Transactions.Add(transaction);
        await context.SaveChangesAsync();
        return transaction;
    }

    public async Task<Transaction> WithdrawAsync(string senderAccountNumber, decimal amount)
    {
        var senderAccount = await context.Accounts
            .Include(a => a.SentTransactions)
            .Include(a => a.ReceivedTransactions)
            .FirstOrDefaultAsync(a => a.AccountNumber == senderAccountNumber);
        
        if (senderAccount == null)
        {
            throw new Exception("Account not found");
        }
        
        var balance = senderAccount.GetBalance();


        var transaction = Transaction.Factories.Withdraw(senderAccount, balance, amount);
        
        context.Transactions.Add(transaction);
        await context.SaveChangesAsync();
        return transaction;
    }

    public async Task<Transaction> TransferAsync(string senderAccountNumber, string receiverAccountNumber, decimal amount)
    {
        var senderAccount = await context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == senderAccountNumber);
        var receiverAccount = await context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == receiverAccountNumber);
        
        if (senderAccount == null)
        {
            throw new Exception("Account not found");
        }
        
        if (receiverAccount == null)
        {
            throw new Exception("Account not found");
        }
        
        var balance = senderAccount.GetBalance();

        var transaction = Transaction.Factories.Transfer(senderAccount, receiverAccount, balance, amount);
        
        context.Transactions.Add(transaction);
        await context.SaveChangesAsync();
        return transaction;
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