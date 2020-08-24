using Paschoalotto.Dominio.Entidade;
using Paschoalotto.Dominio.Model.Response;
using Paschoalotto.Dominio.Repositorios.Interfaces.Proposta;
using Paschoalotto.Dominio.Service.Interfaces;
using Paschoalotto.Dominio.Transacoes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paschoalotto.Dominio.Service
{
    public class PropostaService : Service, IPropostaService
    {
        private readonly IPropostaRepositorio _propostaRepositorio;
        public PropostaService(IUnitOfWork unitOfWork, IPropostaRepositorio propostaRepositorio) : base(unitOfWork)
        {
            _propostaRepositorio = propostaRepositorio;
        }

        public async Task<PropostaModel> ObterPropostaPorId(int id)
        {
            PropostaEntity result = await _propostaRepositorio.ObterPropostaPorId(id);
            
            return PropostaEntity.CriarComModel(result);
        }
    }
}
