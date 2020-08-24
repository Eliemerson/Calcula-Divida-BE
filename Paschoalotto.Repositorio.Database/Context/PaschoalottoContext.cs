using Microsoft.EntityFrameworkCore;
using Paschoalotto.Repositorio.Database.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Repositorio.Database.Context
{
    public class PaschoalottoContext : DbContext
    {
        public PaschoalottoContext(DbContextOptions<PaschoalottoContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AcordoClientEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DividaClienteEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PropostaEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TipoJurosEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
