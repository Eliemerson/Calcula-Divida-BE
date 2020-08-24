using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paschoalotto.Dominio.Model.Request;
using Paschoalotto.Dominio.Model.Response;
using Paschoalotto.Dominio.Service.Interfaces;

namespace Paschoalotto.ProvadorDados.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcordoController : ControllerBase
    {
        private readonly IAcordoClientService _acordoService;
        public AcordoController(IAcordoClientService acordoService)
        {
            _acordoService = acordoService;
        }

        [HttpPost("salvar-proposta")]
        public async Task<MensagemResponse<AcordoClientModel>> SalvarProposta(AcordoClientModel acordoModel) =>
            await _acordoService.SalvarAcordoCleinte(acordoModel);
    }
}