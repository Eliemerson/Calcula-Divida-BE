
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paschoalotto.Dominio.Model.Response;
using Paschoalotto.Dominio.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Paschoalotto.ProvadorDados.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropostaController : ControllerBase
    {
        private readonly IPropostaService _propostaService;

        public PropostaController(IPropostaService propostaService) 
        {
            _propostaService = propostaService;
        }

        [HttpGet("obter-proposta/{propostaId}")]
        public async Task<PropostaModel> ObterPropostaPorId(int propostaId) => await _propostaService.ObterPropostaPorId(propostaId);
    }
}
