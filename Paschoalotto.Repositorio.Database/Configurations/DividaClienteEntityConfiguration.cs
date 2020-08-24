using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paschoalotto.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Repositorio.Database.Configurations
{
    public class DividaClienteEntityConfiguration : IEntityTypeConfiguration<DividaClienteEntity>
    {
        public void Configure(EntityTypeBuilder<DividaClienteEntity> builder)
        {
            builder.ToTable("DividaCliente", "provedordados");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Valor).HasColumnType("decimal(10, 2)");
        }
    }
}
