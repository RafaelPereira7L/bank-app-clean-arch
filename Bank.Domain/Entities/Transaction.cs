using System.Text.Json.Serialization;

namespace Bank.Domain.Entities;

public enum TransactionType
{
    Deposit,
    Withdrawal,
    Transfer
}
public class Transaction : BaseEntity
{
    public Guid? SenderAccountId { get; init; }
    public Guid? ReceiverAccountId { get; init; }
    public decimal Amount { get; init; }
    public TransactionType Type { get; init; }
    public DateTime TransactionDate { get; init; } = DateTime.UtcNow;
    [JsonIgnore]
    public Account SenderAccount { get; init; }
    [JsonIgnore]
    public Account ReceiverAccount { get; init; }

    private Transaction()
    {
    }

    public static class Factories
    {
        public static Transaction Deposit(Account receiverAccount, decimal amount)
        {
            return new Transaction
            {
                Amount = amount,
                ReceiverAccountId = receiverAccount.Id,
                Type = TransactionType.Deposit
            };
        }

        public static Transaction Withdraw(Account senderAccount, decimal senderBalance, decimal amount)
        {
            if(senderBalance < amount)
            {
                throw new Exception("Insufficient balance");
            }
            
            return new Transaction
            {
                Amount = amount,
                SenderAccountId = senderAccount.Id,
                Type = TransactionType.Withdrawal
            };
        }

        public static Transaction Transfer(Account senderAccount, Account receiverAccount, decimal senderBalance, decimal amount)
        {
            if(senderBalance < amount)
            {
                throw new Exception("Insufficient balance");
            }
            
            return new Transaction
            {
                Amount = amount,
                SenderAccountId = senderAccount.Id,
                ReceiverAccountId = receiverAccount.Id,
                Type = TransactionType.Transfer
            };
        }
    }
}