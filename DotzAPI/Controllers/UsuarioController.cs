using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DotzAPI.Database;
using DotzAPI.Modelos;
using DotzAPI.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

            int.TryParse(User.FindFirst("UsuarioId")?.Value, out var usuarioLogadoId);
            
            return await Servico.AdicionarEnderecoAsync(endereco, usuarioLogadoId);
        }
    }
}
