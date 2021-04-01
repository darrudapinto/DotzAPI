using System.Collections.Generic;
using System.Threading.Tasks;
using DotzAPI.Database;
using DotzAPI.Modelos;
using DotzAPI.Repositorios;

namespace DotzAPI.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio Repositorio;

        public UsuarioServico(IUsuarioRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public async Task<Usuario> AdicionarAsync(AplicacaoDbContexto contexto, Usuario usuario)
        {
            return await Repositorio.AdicionarAsync(contexto, usuario);
        }

        public async Task<Usuario> ObterPorIdAsync(AplicacaoDbContexto contexto, int id)
        {
            return await Repositorio.ObterPorIdAsync(contexto, id);
        }

        public async Task<List<Usuario>> ObterTodosAsync(AplicacaoDbContexto contexto)
        {
            return await Repositorio.ObterTodosAsync(contexto);
        }
    }
}
