using System.ComponentModel.DataAnnotations;

namespace Bank.Application.DTOs;

public class CreateDepositTransactionDTO
{
    [Required(ErrorMessage = "The Receiver Account Number is required")]
    public string ReceiverAccountNumber { get; init; }
    
    [Required(ErrorMessage = "The Amount is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "The Amount must be greater than 0")]
    [DataType(DataType.Currency)]
    public decimal Amount { get; set; }
}