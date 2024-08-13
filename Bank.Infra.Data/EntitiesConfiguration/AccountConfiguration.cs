using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Infra.Data.EntitiesConfiguration;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.AccountNumber)
            .IsRequired()
            .HasMaxLength(20);
        builder.HasIndex(p => p.AccountNumber)
            .IsUnique();
        builder.Property(p => p.AccountHolderName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(t => t.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();
        builder.Property(t => t.UpdatedAt)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();
        builder.HasMany(a => a.SentTransactions)
            .WithOne(t => t.SenderAccount)
            .HasForeignKey(t => t.SenderAccountId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(a => a.ReceivedTransactions)
            .WithOne(t => t.ReceiverAccount)
            .HasForeignKey(t => t.ReceiverAccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}