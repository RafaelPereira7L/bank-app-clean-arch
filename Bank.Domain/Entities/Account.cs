using System.Diagnostics;

namespace Bank.Domain.Entities;

public class Account : BaseEntity
{
    public string AccountNumber { get; private set; }
    public string AccountHolderName { get; set; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow; 
    public DateTime UpdatedAt { get; } = DateTime.UtcNow;
    
    public ICollection<Transaction> SentTransactions { get; set; }
    public ICollection<Transaction> ReceivedTransactions { get; set; }
    
    public Account()
    {
        AccountNumber = new Random() 
            .Next(100000000, 999999999)
            .ToString();
    }

    public decimal GetBalance()
    {
        var receivedAmount = ReceivedTransactions?.Sum(x => x.Amount) ?? 0;
        var sentAmount = SentTransactions?.Sum(x => x.Amount) ?? 0;
    
        return receivedAmount - sentAmount;
    }

}