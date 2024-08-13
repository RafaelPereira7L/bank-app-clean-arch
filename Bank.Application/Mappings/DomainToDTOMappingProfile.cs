using AutoMapper;
using Bank.Application.DTOs;
using Bank.Domain.Entities;

namespace Bank.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Account, CreateAccountDTO>().ReverseMap();
        CreateMap<Account, AccountWithBalanceDto>().ReverseMap();
        CreateMap<Transaction, CreateDepositTransactionDTO>().ReverseMap();
        CreateMap<Transaction, CreateWithdrawTransactionDTO>().ReverseMap();
        CreateMap<Transaction, CreateTransferTransactionDTO>().ReverseMap();
    }
}