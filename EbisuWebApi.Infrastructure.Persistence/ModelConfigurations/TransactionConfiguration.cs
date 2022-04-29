using EbisuWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Infrastructure.Persistence.ModelConfigurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.ToTable("Transaction");
            builder.HasKey(transaction => transaction.TransactionId);
            builder.Property(transaction => transaction.TransactionId).UseMySqlIdentityColumn();
            builder.Property(transaction => transaction.TransactionDate).IsRequired();
            builder.Property(transaction => transaction.Amount).IsRequired();
            builder.Property(transaction => transaction.Description).IsRequired().HasMaxLength(255);
        }
    }
}
