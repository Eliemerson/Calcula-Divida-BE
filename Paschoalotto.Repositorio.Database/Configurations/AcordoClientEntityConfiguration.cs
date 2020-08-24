using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paschoalotto.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Repositorio.Database.Configurations
{
    public class AcordoClientEntityConfiguration : IEntityTypeConfiguration<AcordoClientEntity>
    {
        public void Configure(EntityTypeBuilder<AcordoClientEntity> builder)
        {
            builder.ToTable("AcordoCliente", "provedordados");
            builder.Property(x => x.ValorParcela).HasColumnType("decimal(10, 2)");
            builder.Property(x => x.ValorFinal).HasColumnType("decimal(10, 2)");
            builder.Property(x => x.Juros).HasColumnType("decimal(10, 2)");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Proposta).WithOne(x => x.Acordo).HasForeignKey<AcordoClientEntity>(x => x.PropostaId);
        }
    }
}
