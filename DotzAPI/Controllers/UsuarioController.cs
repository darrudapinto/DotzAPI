using System.Collections.Generic;
using System.Threading.Tasks;
using DotzAPI.Database;
using DotzAPI.Modelos;
using DotzAPI.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace DotzAPI.Controllers
{
    [ApiController]
    [Route("v1/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServico Servico;

        public UsuarioController(IUsuarioServico servico)
        {
            Servico = servico;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Usuario>>> Get([FromServices] AplicacaoDbContexto contexto)
        {
            return await Servico.ObterTodosAsync(contexto);
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<ActionResult<Usuario>> Post([FromServices] AplicacaoDbContexto contexto, [FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await Servico.AdicionarAsync(contexto, usuario);
        }
    }
}
