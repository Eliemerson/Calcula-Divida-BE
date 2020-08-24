using Microsoft.EntityFrameworkCore;
using Paschoalotto.Dominio.Entidade;
using Paschoalotto.Dominio.Enum;
using Paschoalotto.Dominio.Repositorios.Interfaces.Proposta;
using Paschoalotto.Repositorio.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paschoalotto.Repositorio.Database.Repositorios
{
    public class PropostaRepositorio :RepositorioBase<PropostaEntity>,  IPropostaRepositorio
    {
        public PropostaRepositorio(PaschoalottoContext context) : base(context) { }

        public async Task<PropostaEntity> ObterPropostaPorId(int id) =>
            await NoTracking().Include(x => x.Juros).Include(x => x.Divida).Where(x => x.Id == id && x.Status == StatusEnumProposta.AguardandoConfirmacao).FirstOrDefaultAsync();
    }
}
