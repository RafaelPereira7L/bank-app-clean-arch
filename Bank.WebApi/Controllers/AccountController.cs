using Bank.Application.DTOs;
using Bank.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController(IAccountService accountService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAccounts()
    {
        var accounts = await accountService.GetAccountsAsync();
        return Ok(accounts);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAccountById(Guid id)
    {
        var account = await accountService.GetAccountByIdAsync(id);
        return Ok(account);
    }
    
    [HttpGet("{accountNumber}")]
    public async Task<IActionResult> GetAccountByAccountNumber(string accountNumber)
    {
        var account = await accountService.GetAccountByAccountNumberAsync(accountNumber);
        return Ok(account);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAccount(CreateAccountDTO account)
    {  
        var accountCreated = await accountService.CreateAccountAsync(account);
        return Created("", accountCreated);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAccount(Guid id)
    {
        await accountService.DeleteAccountAsync(id);
        return NoContent();
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAccount(Guid id, UpdateAccountDTO account)
    {
        await accountService.UpdateAccountAsync(id, account);
        
        return NoContent();
    }
}