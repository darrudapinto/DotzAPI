using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DotzAPI.Database;
using DotzAPI.Modelos;
using DotzAPI.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotzAPI.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio Repositorio;
        private readonly AplicacaoDbContexto Contexto;

        public UsuarioServico(IUsuarioRepositorio repositorio, [FromServices] AplicacaoDbContexto contexto)
        {
            Repositorio = repositorio;
            Contexto = contexto;
        }

        public async Task<Usuario> AdicionarAsync(Usuario usuario)
        {
            return await Repositorio.AdicionarAsync(usuario);
        }

        public async Task<Usuario> AdicionarEnderecoAsync(Endereco endereco, string email)
        {
            var usuario = await ObterPorEmailAsync(email);
            
            usuario.Endereco = endereco;
            return await Repositorio.AtualizarAsync(usuario);
        }

        public async Task<Usuario> AdicionarPontoDotzAsync(PontoDotz pontoDotz, string email)
        {
            var usuario = await ObterPorEmailAsync(email);

            if (usuario.PontosDotz == null)
                usuario.PontosDotz = new Collection<PontoDotz>();
            
            usuario.PontosDotz.Add(pontoDotz);
            usuario.AtualizarPontosDotzAcumulados();
            
            return await Repositorio.AtualizarAsync(usuario);            
        }

        public async Task<Usuario> ObterPorIdAsync(int id)
        {
            return await Repositorio.ObterPorIdAsync(id);
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            return await Repositorio.ObterPorEmailAsync(email);
        }

        public async Task<List<Usuario>> ObterTodosAsync()
        {
            return await Repositorio.ObterTodosAsync();
        }
    }
}
