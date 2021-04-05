using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DotzAPI.Modelos;
using DotzAPI.Servicos;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await Servico.ObterTodosAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Usuario>> Get([FromRoute] int id)
        {
            return await Servico.ObterPorIdAsync(id);
        }

        [HttpGet]
        [Route("obterPorEmail")]
        public async Task<ActionResult<Usuario>> Get(string email)
        {
            return await Servico.ObterPorEmailAsync(email);
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<ActionResult<Usuario>> Post([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await Servico.AdicionarAsync(usuario);
        }

        [HttpPost]
        [Route("adicionar/endereco")]
        [Authorize]
        public async Task<ActionResult<Usuario>> Post([FromBody] Endereco endereco)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuarioLogadoEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            return await Servico.AdicionarEnderecoAsync(endereco, usuarioLogadoEmail);
        }

        [HttpPost]
        [Route("adicionar/pontoDotz")]
        [Authorize]
        public async Task<ActionResult<Usuario>> Post([FromBody] PontoDotz pontoDotz)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuarioLogadoEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            return await Servico.AdicionarPontoDotzAsync(pontoDotz, usuarioLogadoEmail);
        }
    }
}
