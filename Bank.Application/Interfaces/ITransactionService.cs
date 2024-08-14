using Bank.Application.DTOs;
using Bank.Domain.Entities;

namespace Bank.Application.Interfaces;

public interface ITransactionService
{
    Task<Transaction> DepositAsync(CreateDepositTransactionDTO transactionDto);
    Task<Transaction> WithdrawAsync(CreateWithdrawTransactionDTO transactionDto);
    Task<Transaction> TransferAsync(CreateTransferTransactionDTO transactionDto);
    Task<IEnumerable<Transaction>> GetTransactionsAsync(string accountNumber);
}