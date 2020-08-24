
using Paschoalotto.Dominio.Entidade;
using Paschoalotto.Dominio.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paschoalotto.Dominio.Repositorios.Interfaces.Proposta
{
    public interface IPropostaRepositorio
    {
        Task<PropostaEntity> ObterPropostaPorId(int id);
    }
}
