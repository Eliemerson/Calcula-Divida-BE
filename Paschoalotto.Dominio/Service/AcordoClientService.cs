using Paschoalotto.Dominio.Entidade;
using Paschoalotto.Dominio.Enum;
using Paschoalotto.Dominio.Model.Request;
using Paschoalotto.Dominio.Model.Response;
using Paschoalotto.Dominio.Repositorios.Interfaces.AcordoClient;
using Paschoalotto.Dominio.Repositorios.Interfaces.Proposta;
using Paschoalotto.Dominio.Service.Interfaces;
using Paschoalotto.Dominio.Transacoes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paschoalotto.Dominio.Service
{
    public class AcordoClientService : Service, IAcordoClientService
    {
        private readonly IAcordoClientRepositorio _acordoRepositorio;
        private readonly IPropostaRepositorio _propostaRepositorio;
        public AcordoClientService(IUnitOfWork unitOfWork, IAcordoClientRepositorio acordoClientRepositorio, IPropostaRepositorio propostaRepositorio) : base(unitOfWork)
        {
            _acordoRepositorio = acordoClientRepositorio;
            _propostaRepositorio = propostaRepositorio;
        }

        public async Task<MensagemResponse<AcordoClientModel>> SalvarAcordoCleinte(AcordoClientModel acordoModel)
        {
            try
            {
                var propostaEntity = await _propostaRepositorio.ObterPropostaPorId(acordoModel.PropostaId);

                if (propostaEntity == null)
                    return MensagemResponse<AcordoClientModel>.Criar(false, null, "Erro ao Validar Proposta");

                var acordoEntity = AcordoClientEntity.ValidarECriar(acordoModel, propostaEntity);

                if (acordoEntity == null)
                    return MensagemResponse<AcordoClientModel>.Criar(false, null, "Erro ao Validar Proposta");

                propostaEntity.Status = StatusEnumProposta.Confirmado;
                var result = _acordoRepositorio.Salvar(acordoEntity);

                if (result == null)
                    return MensagemResponse<AcordoClientModel>.Criar(false, null, "Erro ao Salvar Acordo");

                await SaveChangesAsync();

                return MensagemResponse<AcordoClientModel>.Criar(true, acordoModel, "Sucesso ao Salvar Acordo");

            }
            catch (Exception ex)
            {

                return MensagemResponse<AcordoClientModel>.Criar(false, null, ex.Message);
            }
       
        }
    }
}
