using LF.Domain.Entities;
using LF.Domain.Enums.LancamentoFinanceiro;
using LF.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace LF.Infrastructure.Data.EntitiesConfiguration
{
    public class LancamentoFinanceiroConfig : IEntityTypeConfiguration<LancamentoFinanceiro>
    {
        public void Configure(EntityTypeBuilder<LancamentoFinanceiro> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Tipo)
                .HasConversion(new EnumToNumberConverter<ETipo, int>());
            builder.Property(e => e.Status)
               .HasConversion(new EnumToNumberConverter<EStatus, int>());
            builder.Property(x => x.Valor)
                .HasPrecision(18, 2);
        }
    }
}
