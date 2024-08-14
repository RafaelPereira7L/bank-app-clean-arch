using System.ComponentModel.DataAnnotations;

namespace Bank.Application.DTOs;

public class UpdateAccountDTO
{
    [Required(ErrorMessage = "The Account Holder Name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string AccountHolderName { get; set; }
}