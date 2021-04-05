using System.Threading.Tasks;
using DotzAPI.Database;
using DotzAPI.Modelos;
using DotzAPI.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotzAPI.Controllers
{
    [ApiController]
    [Route("v1/pontoDotz")]
    public class PontoDotzController : ControllerBase
    {
        private readonly IPontoDotzServico Servico;

        public PontoDotzController(IPontoDotzServico servico)
        {
            Servico = servico;
        }

        [HttpPost]
        [Route("adicionar")]
        [Authorize]
        public async Task<ActionResult<PontoDotz>> Post([FromBody] PontoDotz pontoDotz)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await Servico.AdicionarAsync(pontoDotz);
        }
    }
}
