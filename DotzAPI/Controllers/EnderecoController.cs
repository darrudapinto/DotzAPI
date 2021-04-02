using System.Threading.Tasks;
using DotzAPI.Database;
using DotzAPI.Modelos;
using DotzAPI.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotzAPI.Controllers
{
    [ApiController]
    [Route("v1/endereco")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoServico Servico;

        public EnderecoController(IEnderecoServico servico)
        {
            Servico = servico;
        }

        [HttpPost]
        [Route("adicionar")]
        [Authorize]
        public async Task<ActionResult<Endereco>> Post([FromBody] Endereco endereco)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await Servico.AdicionarAsync(endereco);
        }
    }
}
