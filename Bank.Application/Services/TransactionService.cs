using Bank.Application.DTOs;
using Bank.Application.Interfaces;
using Bank.Domain.Entities;
using Bank.Domain.Exceptions;
using Bank.Domain.Interfaces;

namespace Bank.Application.Services;

public class TransactionService(IAccountRepository accountRepository, ITransactionRepository transactionRepository) : ITransactionService
{
    public async Task<Transaction> DepositAsync(CreateDepositTransactionDTO depositDto)
    {
        var receiverAccount = await accountRepository.GetAccountByAccountNumberAsync(depositDto.ReceiverAccountNumber);
        
        if (receiverAccount is null)
            throw new AccountNotFoundException();
        
        var transaction = Transaction.Factories.Deposit(receiverAccount, depositDto.Amount);
        
        await transactionRepository.DepositAsync(transaction);
        return transaction;
    }

    public async Task<Transaction> WithdrawAsync(CreateWithdrawTransactionDTO withdrawDto)
    {
        var senderAccount = await accountRepository.GetAccountByAccountNumberAsync(withdrawDto.SenderAccountNumber);
        
        if (senderAccount is null)
            throw new AccountNotFoundException();
        
        var balance = senderAccount.GetBalance();
        var transaction = Transaction.Factories.Withdraw(senderAccount, balance, withdrawDto.Amount);
        
        await transactionRepository.WithdrawAsync(transaction);
        return transaction;
    }

    public async Task<Transaction> TransferAsync(CreateTransferTransactionDTO transferDto)
    {
        var senderAccount = await accountRepository.GetAccountByAccountNumberAsync(transferDto.SenderAccountNumber);
        var receiverAccount = await accountRepository.GetAccountByAccountNumberAsync(transferDto.ReceiverAccountNumber);
        
        if (senderAccount == null || receiverAccount == null)
            throw new AccountNotFoundException();
        
        var senderBalance = senderAccount.GetBalance();
        var transaction = Transaction.Factories.Transfer(senderAccount, receiverAccount, senderBalance, transferDto.Amount);
        
        await transactionRepository.TransferAsync(transaction);
        return transaction;
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsAsync(string accountNumber)
    {
        return await transactionRepository.GetTransactionsAsync(accountNumber);
    }
}