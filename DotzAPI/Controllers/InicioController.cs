using System;
using System.Threading.Tasks;
using DotzAPI.Database;
using DotzAPI.Modelos;
using DotzAPI.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotzAPI.Controllers
{
    [Route("v1")]
    public class InicioController : ControllerBase
    {
        private readonly IUsuarioServico Servico;

        public InicioController(IUsuarioServico servico)
        {
            Servico = servico;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autenticar([FromServices] AplicacaoDbContexto contexto, [FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuarioValido = await Servico.ObterPorIdAsync(contexto, usuario.Id);
            if(usuarioValido == null)
                return NotFound(new { message = "Usuário inválido" });

            if(usuario.Email != usuarioValido.Email || usuario.Senha != usuarioValido.Senha)
                return Unauthorized(new { message = "Dados incorretos" });

            var token = TokenServico.GerarToken(usuarioValido);
            usuarioValido.Senha = "****";

            return new
            {
                user = usuarioValido,
                token = token
            };            
        }

        [HttpGet]
        [Route("anonimo")]
        [AllowAnonymous]
        public string Anonimo() => "Anônimo!";

        [HttpGet]
        [Route("Autenticado")]
        [Authorize]
        public string Autenticado() => String.Format("Autenticado! Bem vindo, {0}", User.Identity.Name);
    }
}