using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Infra.Data.EntitiesConfiguration;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Amount)
            .IsRequired()
            .HasColumnType("decimal(10,2)");
        builder.Property(p => p.Type)
            .HasConversion(c => c.ToString(), c => Enum.Parse<TransactionType>(c))
            .IsRequired();
        builder.Property(t => t.TransactionDate)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();
        builder.HasOne(t => t.SenderAccount)
            .WithMany(a => a.SentTransactions)
            .HasForeignKey(t => t.SenderAccountId)
            .OnDelete(DeleteBehavior.Restrict); 
        builder.HasOne(t => t.ReceiverAccount)
            .WithMany(a => a.ReceivedTransactions)
            .HasForeignKey(t => t.ReceiverAccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}