using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paschoalotto.Dominio.Entidade;

namespace Paschoalotto.Repositorio.Database.Configurations
{
    public class PropostaEntityConfiguration: IEntityTypeConfiguration<PropostaEntity>
    {
        public void Configure(EntityTypeBuilder<PropostaEntity> builder)
        {
            builder.ToTable("Propostas", "provedordados");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Juros).WithOne(x => x.Proposta).HasForeignKey<PropostaEntity>(x => x.JurosId);
            builder.HasOne(x => x.Divida).WithOne(x => x.Proposta).HasForeignKey<PropostaEntity>(x => x.DividaId);
        }
    }
}
