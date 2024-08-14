using Bank.Domain.Entities;

namespace Bank.Domain.Interfaces;

public interface ITransactionRepository
{
    Task DepositAsync(Transaction transaction);
    Task WithdrawAsync(Transaction transaction);
    Task TransferAsync(Transaction transaction);
    Task<IEnumerable<Transaction>> GetTransactionsAsync(string accountNumber);
}