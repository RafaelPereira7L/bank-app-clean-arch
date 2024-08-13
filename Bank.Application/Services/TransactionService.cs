using Bank.Application.DTOs;
using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using Bank.Domain.Interfaces;

namespace Bank.Application.Services;

public class TransactionService(ITransactionRepository transactionRepository) : ITransactionService
{
    public async Task<Transaction> DepositAsync(CreateDepositTransactionDTO depositDto)
    {
        var depositTransaction = await transactionRepository.DepositAsync(depositDto.ReceiverAccountNumber, depositDto.Amount);
        return depositTransaction;
    }

    public async Task<Transaction> WithdrawAsync(CreateWithdrawTransactionDTO withdrawDto)
    {
        var withdrawTransaction = await transactionRepository.WithdrawAsync(withdrawDto.SenderAccountNumber, withdrawDto.Amount);
        return withdrawTransaction;
    }

    public async Task<Transaction> TransferAsync(CreateTransferTransactionDTO transferDto)
    {
        var transferTransaction = await transactionRepository.TransferAsync(transferDto.SenderAccountNumber, 
            transferDto.ReceiverAccountNumber, 
            transferDto.Amount);
        return transferTransaction;
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsAsync(string accountNumber)
    {
        return await transactionRepository.GetTransactionsAsync(accountNumber);
    }
}