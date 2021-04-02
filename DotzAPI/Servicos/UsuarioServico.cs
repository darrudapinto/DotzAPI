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

        public async Task<Usuario> AdicionarAsync(Usuario usuario)
        {
            return await Repositorio.AdicionarAsync(usuario);
        }

        public async Task<Usuario> AdicionarEnderecoAsync(Endereco endereco, int id)
        {
            var usuario = await ObterPorIdAsync(id);
            usuario.Endereco = endereco;
            return await Repositorio.AtualizarAsync(usuario);
        }

        public async Task<Usuario> ObterPorIdAsync(int id)
        {
            return await Repositorio.ObterPorIdAsync(id);
        }

        public async Task<List<Usuario>> ObterTodosAsync()
        {
            return await Repositorio.ObterTodosAsync();
        }
    }
}
