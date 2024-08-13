using Bank.Application.DTOs;
using Bank.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionController(ITransactionService transactionService) : ControllerBase
{
    [HttpGet("{accountNumber}")]
    public async Task<IActionResult> GetTransactions(string accountNumber)
    {
        var transactions = await transactionService.GetTransactionsAsync(accountNumber);
        return Ok(transactions);
    }
    
    [HttpPost("deposit")]
    public async Task<IActionResult> CreateDepositTransaction(CreateDepositTransactionDTO depositDto)
    {  
        var depositTransaction = await transactionService.DepositAsync(depositDto);
        return Created("", depositTransaction);
    }
    
    [HttpPost("withdraw")]
    public async Task<IActionResult> CreateWithdrawTransaction(CreateWithdrawTransactionDTO withdrawDto)
    {  
        var withdrawTransaction = await transactionService.WithdrawAsync(withdrawDto);
        return Created("", withdrawTransaction);
    }
    
    [HttpPost("transfer")]
    public async Task<IActionResult> CreateTransferTransaction(CreateTransferTransactionDTO transferDto)
    {  
        var transferTransaction = await transactionService.TransferAsync(transferDto);
        return Created("", transferTransaction);
    }
}