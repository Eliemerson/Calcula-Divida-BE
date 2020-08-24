using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paschoalotto.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Repositorio.Database.Configurations
{
    public class TipoJurosEntityConfiguration: IEntityTypeConfiguration<TipoJurosEntity>
    {
        public void Configure(EntityTypeBuilder<TipoJurosEntity> builder)
        {
            builder.ToTable("TipoJuros", "provedordados");
            builder.HasKey(x => x.Id);
        }
    }
}
