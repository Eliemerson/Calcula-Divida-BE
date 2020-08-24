using Paschoalotto.Dominio.Model.Request;
using Paschoalotto.Dominio.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paschoalotto.Dominio.Service.Interfaces
{
    public interface IAcordoClientService
    {
        Task<MensagemResponse<AcordoClientModel>> SalvarAcordoCleinte(AcordoClientModel acordoModel);
    }
}
