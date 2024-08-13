using Bank.Domain.Entities;

namespace Bank.Domain.Interfaces;

public interface ITransactionRepository
{
    Task<Transaction> DepositAsync(string receiverAccountNumber, decimal amount);
    Task<Transaction> WithdrawAsync(string senderAccountNumber, decimal amount);
    Task<Transaction> TransferAsync(string senderAccountNumber, string receiverAccountNumber, decimal amount);
    Task<IEnumerable<Transaction>> GetTransactionsAsync(string accountNumber);
}