using Bank.Domain.Entities;

namespace Bank.Application.DTOs;

public class AccountWithBalanceDto
{
    public Guid Id { get; set; }
    public string AccountNumber { get; set; }
    public string AccountHolderName { get; set; }
    public decimal Balance { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public ICollection<Transaction> SentTransactions { get; set; }
    public ICollection<Transaction> ReceivedTransactions { get; set; }
}